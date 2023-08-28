

using ShopCenter.Infrastructure.Enums;

namespace ShopCenter.Infrastructure.Services.DelayReportation;

public class DelayReportService : IDelayReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGetDeliveryTimeService _getDeliveryTimeService;
    public DelayReportService(IUnitOfWork unitOfWork, IGetDeliveryTimeService getDeliveryTimeService)
    {
        _unitOfWork = unitOfWork;
        _getDeliveryTimeService = getDeliveryTimeService;
    }

    public async Task<Result<DelayReportResponse>> DelayReportRegistration(int orderId)
    {
        var response = new Result<DelayReportResponse>();
        try
        {
            var orderInfo = await _unitOfWork.OrderRepository.GetById(orderId);
            CheckOrderId(orderInfo);
            CheckDeliveryTime(orderInfo);
            CheckDuplicateRequest(orderInfo);
            await CheckTrip(orderId, response);
        }
        catch (CustomException ex)
        {
            response.SetError(new CustomError
            {
                Message = ex.Message,
                Code = ex.Data["code"].ToString(),
            });
        }
        catch (Exception)
        {

            response.SetError(new CustomError
            {
                Message = Exceptions.ServereError.ToDisplay()
            });
        }

        return response;
    }

    private async Task AddDepayReportToDb(int orderId, int newDeliveryTime)
    {
        var delayReport = new DelayReport
        {
            OrderId = orderId,
            ReportedTime = DateTime.Now,
            NewDeliveryTime = newDeliveryTime
        };
        await _unitOfWork.DelayReportRepository.Add(delayReport);
    }

    private async Task CheckTrip(int orderId, Result<DelayReportResponse> response)
    {
        int newDeliveryTime = 0;
        var requiredNewOrderTimeStatus = new List<TripStatusEnum> { TripStatusEnum.ASSIGNED, TripStatusEnum.AT_VENDOR, TripStatusEnum.PICKED };
        var tripStatus = await _unitOfWork.TripRepository.GetTripStatus(orderId);
        if (tripStatus == null || !requiredNewOrderTimeStatus.Contains((TripStatusEnum)tripStatus.TripStatusId))
        {
            //add to queue
            var delayQueueItem = new DelayQueue
            {
                OrderId = orderId,
                InsertTime = DateTime.Now,

            };
            await _unitOfWork.DelayQueueRepository.AddAsync(delayQueueItem);
            DelayReportResponse deliveryReportResponse = new DelayReportResponse
            {
                Message = BusinessLogicMessages.ReportWillBeInProgressed.ToString(),
            };

            response.Data = deliveryReportResponse;
        }

        else
        {
            //get new delivery time 
            var deliveryTimeData = await _getDeliveryTimeService.GetNewDeliveryTime();
            if (deliveryTimeData.HasError)

                throw new CustomException(deliveryTimeData.Error.Message, deliveryTimeData.Error.Code);

            DelayReportResponse deliveryReportResponse = new DelayReportResponse
            {
                Message = String.Format(BusinessLogicMessages.NewDeliveryTime.ToDisplay(), deliveryTimeData.Data?.Data?.Eta)
            };
            newDeliveryTime = deliveryTimeData.Data.Data.Eta;
            response.Data = deliveryReportResponse;

        }
        await AddDepayReportToDb(orderId, newDeliveryTime);
  
    }

    private void CheckDuplicateRequest(Order orderInfo)
    {
        if (orderInfo.DelayQueues?.Any(e => !e.IsProgressed) ?? false)
            throw new CustomException(Exceptions.DuplicateReport.ToDisplay(), Exceptions.DuplicateReport.ToString());
    }

    private void CheckDeliveryTime(Order orderInfo)
    {
        if (orderInfo.OrderTime.AddMinutes(orderInfo.DeliveryTime) > DateTime.Now)
            throw new CustomException(Exceptions.CanNotReportDelay.ToDisplay(), Exceptions.CanNotReportDelay.ToString());
        var lastReport = orderInfo.DelayReports?.LastOrDefault();
        if (lastReport != null && lastReport.ReportedTime.AddMinutes(lastReport.NewDeliveryTime) > DateTime.Now)
            throw new CustomException(Exceptions.CanNotReportDelay.ToDisplay(), Exceptions.CanNotReportDelay.ToString());
    }

    private void CheckOrderId(Order orderInfo)
    {
        if (orderInfo == null)
            throw new CustomException(Exceptions.OrderNotFound.ToDisplay(), Exceptions.OrderNotFound.ToString());

    }
}

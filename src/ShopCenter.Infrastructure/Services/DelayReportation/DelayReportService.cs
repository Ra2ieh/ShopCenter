

namespace ShopCenter.Infrastructure.Services.DelayReportation;

public class DelayReportService: IDelayReportService
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
                NewDeliveryTime = String.Format("کاربر گرامی درخواست شما ثبت شد و توسط همکاران ما بررسی شده و در اسرع وقت با شما تماس خواهند گرفت")
            };

            response.Data = deliveryReportResponse;
        }

        else
        {
            //get new time 
            var deliveryTimeData = await _getDeliveryTimeService.GetNewDeliveryTime();
            if (deliveryTimeData.HasError)
            {
                response.Error = deliveryTimeData.Error;
                return response;
            }
            //update table and time 
            DelayReportResponse deliveryReportResponse = new DelayReportResponse
            {
                NewDeliveryTime = String.Format("زمان تحویل جدید تا {0} دقیقه دیگر", deliveryTimeData.Data.Data.Eta)
            };

            response.Data = deliveryReportResponse;
           
        }

        var delayReport = new DelayReport
        {
            OrderId = orderId,
            ReportedTime = DateTime.Now,
        };
        await _unitOfWork.DelayReportRepository.Add(delayReport);
        return response;
    }
}

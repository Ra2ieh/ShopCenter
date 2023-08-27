

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
        //todo eager loading
        var orderInfo=await _unitOfWork.OrderRepository.GetById(orderId);
        if (orderInfo == null)
        {
            response.SetError(new CustomError
            {
                Code = "404",
                Message = "Not found"
            });
            return response;
        }
        if (orderInfo.OrderTime.AddMinutes(orderInfo.DeliveryTime) > DateTime.Now )
        {
            response.SetError(new CustomError
            {
                Code = "412",
                Message = "کاربر گرامی همچنان از زمان انتظار شما باقی مانده است. امکان ثبت تاخیر برای شما فراهم نمی باشد"
            });
            return response;
        }
        var lastReport = orderInfo.DelayReports?.LastOrDefault();
        if (lastReport!=null && lastReport.ReportedTime.AddMinutes(lastReport.NewDeliveryTime) > DateTime.Now)
        {
            response.SetError(new CustomError
            {
                Code = "412",
                Message = "کاربر گرامی همچنان از زمان انتظار شما باقی مانده است. امکان ثبت تاخیر برای شما فراهم نمی باشد"
            });
            return response;
        }
        if (orderInfo.DelayQueues?.Any(e=>!e.IsProgressed) ?? false)
        {
            response.SetError(new CustomError
            {
                Code = "413",
                Message = "کاربر گرامی درخواست پیگیری شما قبلا ثبت شده و توسط همکاران ما در حال بررسی می باشد."
            });
            return response;
        }
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
                Message = String.Format("کاربر گرامی درخواست شما ثبت شد و توسط همکاران ما بررسی شده و در اسرع وقت با شما تماس خواهند گرفت")
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
                Message = String.Format("زمان تحویل جدید تا {0} دقیقه دیگر", deliveryTimeData.Data.Data.Eta)
            };
            newDeliveryTime = deliveryTimeData.Data.Data.Eta;
            response.Data = deliveryReportResponse;
           
        }

        var delayReport = new DelayReport
        {
            OrderId = orderId,
            ReportedTime = DateTime.Now,
            NewDeliveryTime= newDeliveryTime
        };
        await _unitOfWork.DelayReportRepository.Add(delayReport);
        return response;
    }
}

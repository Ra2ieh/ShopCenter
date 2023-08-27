

namespace ShopCenter.Infrastructure.Services.GetDelayQueue;

public class DelayQueueService: IDelayQueueService
{
    private readonly IUnitOfWork _unitOfWork;

    public DelayQueueService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<Result<GetDelayReportationRequestResponse>> GetDelayReportRequest(int agentId)
    {
        var response = new Result<GetDelayReportationRequestResponse>();
        var requests = await _unitOfWork.DelayQueueRepository.GetListAsync();
        if (requests.Any(e => e.AgentId == agentId))
        {
            response.SetError(new CustomError
            {
                Code = "415",
                Message = "شما دارای درخواست باز می باشید.امکان دریافت درخواست دیگر مجاز نیست"
            });
            return response;
        }
        var request= requests.Where(e => e.AgentId ==null).FirstOrDefault();
        var order = new GetDelayReportationRequestResponse
        {
            OrderId = request.OrderId,
        };
        request.AgentId = agentId;
        await _unitOfWork.DelayQueueRepository.Update(request);
        response.Data = order;
        return response;
    }


}

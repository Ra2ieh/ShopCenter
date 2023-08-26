

namespace ShopCenter.Infrastructure.Services.GetDelayQueue;

public interface IDelayQueueService
{
    Task<Result<GetDelayReportationRequestResponse>> GetDelayReportRequest(int agentId);
}

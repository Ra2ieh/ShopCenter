

namespace ShopCenter.Application.Commands;

public class GetDelayReportCommandHandler : IRequestHandler<GetDelayReportCommand, Result<GetDelayReportationRequestResponse>>
{
    private readonly IDelayQueueService _delayQueueService;
    public GetDelayReportCommandHandler(IDelayQueueService delayQueueService)
    {
        _delayQueueService = delayQueueService;
    }
    public Task<Result<GetDelayReportationRequestResponse>> Handle(GetDelayReportCommand request, CancellationToken cancellationToken)
    {
        return _delayQueueService.GetDelayReportRequest(request.AgentId);
    }
}

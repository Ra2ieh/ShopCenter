

namespace ShopCenter.Application.Commands;

public class DelayReportRegistrationCommandHandler : IRequestHandler<DelayReportRegistrationCommand, Result<DelayReportResponse>>
{
    private readonly IDelayReportService _delayReportService;
    public DelayReportRegistrationCommandHandler(IDelayReportService delayReportService)
    {
        _delayReportService = delayReportService;
    }
    public async Task<Result<DelayReportResponse>> Handle(DelayReportRegistrationCommand request, CancellationToken cancellationToken)
    {
        return await _delayReportService.DelayReportRegistration(request.OrderId);
    }
}

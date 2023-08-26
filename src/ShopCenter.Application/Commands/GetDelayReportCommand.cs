namespace ShopCenter.Application.Commands;

public class GetDelayReportCommand:IRequest<Result<GetDelayReportationRequestResponse>>
{
    public int AgentId { get; set; }
}

namespace ShopCenter.Application.Commands;

public class DelayReportRegistrationCommand:IRequest<Result<DelayReportResponse>>
{
    public int OrderId { get; set; }
}

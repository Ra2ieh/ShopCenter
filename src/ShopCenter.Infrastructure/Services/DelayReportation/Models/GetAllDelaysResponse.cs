namespace ShopCenter.Infrastructure.Services.DelayReportation;

public class GetAllDelaysResponse
{
    public GetAllDelaysResponse()
    {
        Items = new List<VendorsWithDelay>();
    }
    public List<VendorsWithDelay> Items { get; set; }
}

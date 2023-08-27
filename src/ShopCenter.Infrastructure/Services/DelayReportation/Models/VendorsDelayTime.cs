

namespace ShopCenter.Infrastructure.Services.DelayReportation.Models;

public class VendorsDelayTime
{
    public VendorsDelayTime()
    {
        DelayTime = new List<int>();
    }
    public List<int> DelayTime { get; set; }
}

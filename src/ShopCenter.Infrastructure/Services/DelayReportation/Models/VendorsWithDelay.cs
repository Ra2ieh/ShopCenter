

namespace ShopCenter.Infrastructure.Services.DelayReportation.Models
{
    public class VendorsWithDelay
    {
        public VendorsWithDelay()
        {
            VendorsDelayTime = new List<int>();
        }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public List<int> VendorsDelayTime { get; set; }
    }
}

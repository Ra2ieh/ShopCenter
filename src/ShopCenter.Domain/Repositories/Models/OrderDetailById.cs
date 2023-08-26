

namespace ShopCenter.Domain.Repositories.Models
{
    public class OrderDetailById
    {
        public int OrderId { get; set; }
        public int DeliveryTime { get; set; }
        public int VendorId { get; set; }
        public int ConsumerId { get; set; }
        public DateTime OrderTime { get; set; }
        public Consumer Consumer { get; set; }
        public Vendor Vendor { get; set; }
        public ICollection<DelayReport> DelayReports { get; set; }
        public ICollection<DelayQueue> DelayQueues { get; set; }
    }
}

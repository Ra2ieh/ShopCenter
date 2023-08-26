

namespace ShopCenter.Domain.Models
{

    public class DelayReport
    {
        public int DelayReportId { get; set; }
        public DateTime ReportedTime { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

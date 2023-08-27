using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Domain.Repositories.Models
{
    internal class VendorDelayReport
    {
        public int DelayReportId { get; set; }
        public int NewDeliveryTime { get; set; }
        public DateTime ReportedTime { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}

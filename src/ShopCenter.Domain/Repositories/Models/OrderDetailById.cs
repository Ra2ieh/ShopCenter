

namespace ShopCenter.Domain.Repositories.Models
{
    public class OrderDetailById
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public int DeliveryTime { get; set; }
    }
}

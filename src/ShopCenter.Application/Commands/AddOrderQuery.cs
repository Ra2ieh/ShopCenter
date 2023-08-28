

namespace ShopCenter.Application.Commands
{
    public class AddOrderCommand:IRequest<Result>
    {
        public int DeliveryTime { get; set; }
        public int VendorId { get; set; }
        public int ConsumerId { get; set; }
    }
}

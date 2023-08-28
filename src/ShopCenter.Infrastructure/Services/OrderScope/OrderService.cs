

namespace ShopCenter.Infrastructure.Services.OrderScope
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> AddOrder(OrderDto order)
        {
            var response = new Result();
            try
            {
                await _unitOfWork.OrderRepository.AddOrder(new Order
                {
                    OrderTime = DateTime.Now,
                    ConsumerId = order.ConsumerId,
                    VendorId = order.VendorId,
                    DeliveryTime = order.DeliveryTime,
                });
            }
            catch (Exception )
            {

                response.SetError(new CustomError
                {
                    Message = Exceptions.ServereError.ToDisplay(),
                    Code = Exceptions.ServereError.ToString(),
                });
            }
            return response;
           
        }
    }
}

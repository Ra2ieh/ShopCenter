namespace ShopCenter.Application.Commands;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Result>
{
    private readonly IOrderService _orderService;
    public AddOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        return _orderService.AddOrder(new OrderDto
        {
            ConsumerId = request.ConsumerId,
            VendorId = request.VendorId,
            DeliveryTime = request.DeliveryTime,
        });
    }
}

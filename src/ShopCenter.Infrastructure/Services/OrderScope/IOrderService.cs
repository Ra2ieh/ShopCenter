namespace ShopCenter.Infrastructure.Services.OrderScope;

public interface IOrderService
{
    Task<Result> AddOrder(OrderDto order);
}

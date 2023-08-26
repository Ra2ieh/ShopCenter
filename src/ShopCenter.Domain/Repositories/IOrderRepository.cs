namespace ShopCenter.Domain.Repositories;
public interface IOrderRepository
{
    Task<Order> GetById(int orderId);
}

namespace ShopCenter.Domain.Repositories;
public interface IOrderRepository
{
    Task<OrderDetailById> GetById(int orderId);
}

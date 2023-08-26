namespace ShopCenter.Infrastructure.Repositories;

public class OrderRepository:IOrderRepository
{
    private readonly ShopCenterDbContext _dbContext;
    public OrderRepository(ShopCenterDbContext shopCenterDbContext)
    {
        _dbContext = shopCenterDbContext;
    }
    public async Task<Order> GetById(int orderId)
    {
     return await _dbContext.Order.Where(e=>e.OrderId==orderId).Include(e=>e.DelayQueues).FirstOrDefaultAsync();
         
    }
}

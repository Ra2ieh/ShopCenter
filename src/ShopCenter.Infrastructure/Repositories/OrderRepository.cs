namespace ShopCenter.Infrastructure.Repositories;

public class OrderRepository
{
    private readonly ShopCenterDbContext _dbContext;
    public OrderRepository(ShopCenterDbContext shopCenterDbContext)
    {
        _dbContext = shopCenterDbContext;
    }
    public async Task<OrderDetailById> GetById(int orderId)
    {
        return await _dbContext.Order.Select(e => new OrderDetailById
        {
            OrderId = e.OrderId,
            DeliveryTime = e.DeliveryTime,
            OrderTime = e.OrderTime,
        }).FirstOrDefaultAsync(e => e.OrderId == orderId);
         
    }
}

using ShopCenter.Domain.Entities;

namespace ShopCenter.Infrastructure.Repositories;

public class DelayQueueRepository : IDelayQueueRepository
{
    private readonly ShopCenterDbContext _dbContext;
    public DelayQueueRepository(ShopCenterDbContext shopCenterDbContext)
    {
        _dbContext = shopCenterDbContext;
    }
    public async Task AddAsync(DelayQueue delayQueue)
    {
        await _dbContext.DelayQueue.AddAsync(delayQueue);
        await _dbContext.SaveChangesAsync();
    }

    public Task GetAsync(DelayQueue delayQueue)
    {
        throw new NotImplementedException();
    }
}

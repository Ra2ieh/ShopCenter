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

    public async Task<List<DelayQueue>> GetListAsync()
    {
       return await _dbContext.DelayQueue.Where(e=>!e.IsProgressed).ToListAsync();
    }
    public async Task Update(DelayQueue delayQueue)
    {
         _dbContext.DelayQueue.Update(delayQueue);
        await _dbContext.SaveChangesAsync();
    }
}

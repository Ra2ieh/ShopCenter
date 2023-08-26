namespace ShopCenter.Domain.Repositories;

public interface IDelayQueueRepository
{
    Task AddAsync(DelayQueue delayQueue);

    Task<List<DelayQueue>> GetListAsync();
    Task Update(DelayQueue delayQueue);
}

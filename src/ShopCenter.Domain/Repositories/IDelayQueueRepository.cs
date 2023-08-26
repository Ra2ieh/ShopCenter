namespace ShopCenter.Domain.Repositories;

public interface IDelayQueueRepository
{
    Task AddAsync(DelayQueue delayQueue);

    Task GetAsync(DelayQueue delayQueue);
}

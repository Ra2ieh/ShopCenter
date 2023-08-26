

namespace ShopCenter.Domain.Entities;

public class DelayQueue
{
    public int DelayQueueId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public DateTime InsertTime { get; set; }
}

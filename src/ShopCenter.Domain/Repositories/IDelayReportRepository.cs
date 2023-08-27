

namespace ShopCenter.Domain.Repositories;

public interface IDelayReportRepository
{
    Task Add(DelayReport delayReport);
    Task<List<IGrouping<Vendor, DelayReport>>> GetListAsync();
}

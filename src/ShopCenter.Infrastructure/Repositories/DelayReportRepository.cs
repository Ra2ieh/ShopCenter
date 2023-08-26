

namespace ShopCenter.Infrastructure.Repositories;

public class DelayReportRepository: IDelayReportRepository
{
    private readonly ShopCenterDbContext _dbContext;
    public DelayReportRepository(ShopCenterDbContext shopCenterDbContext)
    {
        _dbContext = shopCenterDbContext;
    }
    public async Task Add(DelayReport delayReport)
    {
        await _dbContext.AddAsync(delayReport);
        await _dbContext.SaveChangesAsync();
    }
}

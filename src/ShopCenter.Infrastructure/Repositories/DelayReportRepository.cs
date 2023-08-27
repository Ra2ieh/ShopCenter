

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

    public async Task<List<IGrouping<Vendor,DelayReport>>> GetListAsync()
    {
      return await _dbContext.Delay_Reports.Where(e=>e.NewDeliveryTime!=0 && e.ReportedTime>=DateTime.Now.AddDays(-7)).Include(e=>e.Order).ThenInclude(e=>e.Vendor).GroupBy(e=>e.Order.Vendor).ToListAsync();
      
    }
}

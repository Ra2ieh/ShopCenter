using ShopCenter.Infrastructure.Repositories;

namespace ShopCenter.Infrastructure.SeedOfWork;

public class UnitOfWork : IUnitOfWork
{

    private readonly ShopCenterDbContext _context;
    private readonly Lazy<ITripRepository> _tripRepository;
    private readonly Lazy<IDelayReportRepository> _delayReportRepository;
    private readonly Lazy<IDelayQueueRepository> _delayQueueRepository;
    private readonly Lazy<IOrderRepository> _orderRepository;
    public UnitOfWork(ShopCenterDbContext context)
    {
        _context = context;
        _tripRepository = new Lazy<ITripRepository>(() => new TripRepository(_context));
        _delayReportRepository = new Lazy<IDelayReportRepository>(() => new DelayReportRepository(_context));
        _delayQueueRepository = new Lazy<IDelayQueueRepository>(() => new DelayQueueRepository(_context));
        _orderRepository=new Lazy<IOrderRepository>(() => new OrderRepository(_context));
    }

    public ITripRepository TripRepository => _tripRepository.Value;

    public IDelayReportRepository DelayReportRepository => _delayReportRepository.Value;

    public IDelayQueueRepository DelayQueueRepository => _delayQueueRepository.Value;

    public IOrderRepository OrderRepository => _orderRepository.Value;
}

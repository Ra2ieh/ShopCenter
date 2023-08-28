namespace ShopCenter.Infrastructure;

public class ShopCenterDbContext : DbContext
{
    #region constructor
    public ShopCenterDbContext(DbContextOptions<ShopCenterDbContext> options) : base(options)
    {

    }

    #endregion
    public DbSet<Vendor> Vendor { get; set; }
    public DbSet<Agent> Agent { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Trip> Trip { get; set; }
    public DbSet<TripStatus> TripStatus { get; set; }
    public DbSet<DelayReport> Delay_Reports { get; set; }
    public DbSet<DelayQueue> DelayQueue { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TripStatusEntityConfiguration());
        modelBuilder.ApplyConfiguration(new VendorEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AgentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ConsumerEntityConfiguration());

    }
}

namespace ShopCenter.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ShopCenterDbContext _dbContext;
        public TripRepository(ShopCenterDbContext shopCenterDbContext)
        {
            _dbContext = shopCenterDbContext;
        }
        public Task<TripStatus> GetTripStatus(int orderId)
        {
            var status = _dbContext.Trip.Where(e => e.OrderId == orderId).Select(e => e.TripStatus).FirstOrDefaultAsync();
            return status;
        }
    }
}

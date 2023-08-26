

namespace ShopCenter.Domain.Repositories;

public interface ITripRepository
{
    Task<TripStatus> GetTripStatus(int orderId);
}

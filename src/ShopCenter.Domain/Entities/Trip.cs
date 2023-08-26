namespace ShopCenter.Domain.Models;

public class Trip
{
    public int TripId { get; set; }
    public int OrderId { get; set; }
    public int TripStatusId { get; set; }
    public TripStatus TripStatus { get; set; }
    public Order Order { get; set; }
}

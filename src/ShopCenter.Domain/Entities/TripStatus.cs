

namespace ShopCenter.Domain.Models;
public class TripStatus
{
    public int TripStatusId { get; set; }
    [MaxLength(30)]
    public string TripStatusTitle { get; set; }
}

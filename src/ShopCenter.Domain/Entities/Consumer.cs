namespace ShopCenter.Domain.Models;
public class Consumer
{
    public int ConsumerId { get; set; }
    [MaxLength(20)]
    public string ConsumerName { get; set; }
    [MaxLength(11)]
    public string PhoneNumber { get; set; }
    public ICollection<Order> Orders { get; set; }
}

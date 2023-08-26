namespace ShopCenter.Domain.Models;
public class Consumer
{
    public int ConsumerId { get; set; }
    public string ConsumerName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Order> Orders { get; set; }
}

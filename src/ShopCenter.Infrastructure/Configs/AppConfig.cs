namespace ShopCenter.Infrastructure.Configs;
public class AppConfig
{
    public AppConfig()
    {
        ErrorMessages = new List<ErrorMessage>();
        BusinessMessages=new List<BusinessMessage>();
    }
    public GetDeliveryTimeConfig GetDeliveryTimeConfig { get; set; }
    public List<ErrorMessage> ErrorMessages { get; set; }
    public List<BusinessMessage> BusinessMessages { get; set; }
}

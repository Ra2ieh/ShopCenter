namespace ShopCenter.Infrastructure.ExternalServices.GetDeliveryTime;

public class GetDeliveryTimeDataModel
{
    [JsonProperty("eta")]
    public int Eta { get; set; }
}

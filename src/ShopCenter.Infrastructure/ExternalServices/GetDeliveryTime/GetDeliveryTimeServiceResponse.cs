
namespace ShopCenter.Infrastructure.ExternalServices.GetDeliveryTime
{
    public class GetDeliveryTimeServiceResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("data")]
        public GetDeliveryTimeDataModel Data { get; set; }
    }
}

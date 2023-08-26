

using System.Net.Http;

namespace ShopCenter.Infrastructure.ExternalServices.GetDeliveryTime;

public class GetDeliveryTimeService : IGetDeliveryTimeService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public GetDeliveryTimeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Result<GetDeliveryTimeServiceResponse>> GetNewDeliveryTime()
    {
        var result = new Result<GetDeliveryTimeServiceResponse>();
        var client = _httpClientFactory.CreateClient("deliveryTimeService");
        var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri(String.Format("https://run.mocky.io/{0}", "v3/122c2796-5df4-461c-ab75-87c1192b17f7"));
       var response = await client.SendAsync(httpRequestMessage);
        if (response.IsSuccessStatusCode)
        {
            var apiResult = await response.Content.ReadAsStringAsync();
            result.Data = JsonConvert.DeserializeObject<GetDeliveryTimeServiceResponse>(apiResult);
        }
        else
        {
            result.SetError(new CustomError
            {
                Code = response.StatusCode.ToString(),
                Message = "خطا در برقراری ارتباط.لطفا مجددا تلاش نمایید"
            });
        }
        return result;
    }
}

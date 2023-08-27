using ApiHelper;
using Newtonsoft.Json;
using ShopCenter.Infrastructure.Services.DelayReportation;
using System.Net;

namespace FunctionalTest;

public class RegistrationShould : IClassFixture<TestServerFixture>
{
    private readonly TestServerFixture _testServerFixture;
    public RegistrationShould(TestServerFixture testServerFixture)
    {
        _testServerFixture = testServerFixture;
    }
    [Fact]

    public async Task RegistrationShouldReturnNewDeliveryTime()
    {
        int orderId = 1;
        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri(string.Format(Endpoints.Registeration, orderId));
        var response = await _testServerFixture.Client.SendAsync(httpRequestMessage);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Result<DelayReportResponse>>(responseString);

        Assert.Equal("زمان تحویل جدید تا 14 دقیقه دیگر", result?.Data?.Message);
    }


}

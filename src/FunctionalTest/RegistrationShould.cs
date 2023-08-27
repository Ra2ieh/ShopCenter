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
        var client=_testServerFixture.CreateClient();
        var response = await client.SendAsync(httpRequestMessage);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<DelayReportResponse>(responseString);

        Assert.Equal("زمان تحویل جدید تا 14 دقیقه دیگر", result?.Message);
    }
    [Fact]
    public async Task RegistrationShouldReturnErrorCode412()
    {
        int orderId = 1;
        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri(string.Format(Endpoints.Registeration, orderId));
        var client = _testServerFixture.CreateClient();
        var response = await client.SendAsync(httpRequestMessage);

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<CustomError>(responseString);

        Assert.Equal("412", result?.Code);
    }
    [Fact]
    public async Task RegistrationShouldReturnErrorCode413()
    {
        int orderId = 10;
        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri(string.Format(Endpoints.Registeration, orderId));
        var client = _testServerFixture.CreateClient();
        var response = await client.SendAsync(httpRequestMessage);

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<CustomError>(responseString);

        Assert.Equal("413", result?.Code);
    }
    [Fact]
    public async Task RegistrationShouldReturnInProgressMessage()
    {
        int orderId = 20;
        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri(string.Format(Endpoints.Registeration, orderId));
        var client = _testServerFixture.CreateClient();
        var response = await client.SendAsync(httpRequestMessage);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<DelayReportResponse>(responseString);

        Assert.Equal("کاربر گرامی درخواست شما ثبت شد و توسط همکاران ما بررسی شده و در اسرع وقت با شما تماس خواهند گرفت", result?.Message);
    }

}

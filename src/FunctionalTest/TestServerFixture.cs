using Microsoft.AspNetCore.Builder;

namespace FunctionalTest;
public class TestServerFixture : IDisposable
{
    private readonly TestServer _testServer;
    public HttpClient Client;
    private readonly string _environment = "Development";
    public TestServerFixture()
    {


        var builder = new WebHostBuilder();
        builder.UseEnvironment(_environment);

        _testServer = new TestServer(builder);

        Client = _testServer.CreateClient();

    }

    public void Dispose()
    {
        Client.Dispose();
        _testServer.Dispose();
    }

    public static WebApplication ConfigureService(this WebApplicationBuilder builder)
    {

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DelayReportRegistrationCommandHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetDelayReportCommandHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllDelaysQueryHandler).Assembly));

        builder.Services.InstallServicesInAssemblies(builder.Configuration);
        return builder.Build();
    }
}

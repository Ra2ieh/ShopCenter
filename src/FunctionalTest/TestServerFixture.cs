using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using ShopCenter.Api;

namespace FunctionalTest;
public class TestServerFixture :  WebApplicationFactory<Program>
{

    private readonly string _environment = "Development";

    protected override IHost CreateHost(IHostBuilder builder)
    {

        return base.CreateHost(builder);
    }




}

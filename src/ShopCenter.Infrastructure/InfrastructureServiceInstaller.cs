



namespace ShopCenter.Infrastructure;

public class InfrastructureServiceInstaller:IServiceInstaller
{
 public void InstallServices(IServiceCollection services, IConfiguration appSettings)
    {
        var optionBuilder=new DbContextOptionsBuilder();
        optionBuilder.LogTo(Console.WriteLine);
        services.AddHttpClient("deliveryTimeService", client =>
        {
            var baseUrl = "https://run.mocky.io";
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = TimeSpan.FromSeconds(30);
        }
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDelayReportService, DelayReportService>();
        services.AddScoped<IGetDeliveryTimeService, GetDeliveryTimeService>();
        services.AddScoped<IDelayQueueService, DelayQueueService>();
        services.AddScoped<IGetAllDelaysService, GetAllDelaysService>();
        services.AddDbContext<ShopCenterDbContext>(options =>
        options.UseSqlServer(appSettings.GetConnectionString("ShopCenterDbConectionString"))
        );
        
        //appSettings.GetSection("AppConfig").Get<AppConfig>();
    }
}

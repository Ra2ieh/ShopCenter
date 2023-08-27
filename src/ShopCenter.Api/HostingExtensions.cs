namespace ShopCenter.Api
{
    public static class HostingExtensions
    {
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
        public static WebApplication ConfigurePileLine(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            return app;
        }
    }
}

namespace ShopCenter.Infrastructure.Services.DelayReportation;

public interface IDelayReportService
{
    Task<Result<DelayReportResponse>> DelayReportRegistration(int orderId);
}



namespace ShopCenter.Infrastructure.Services.DelayReportation;

public interface IGetAllDelaysService
{
    Task<Result<GetAllDelaysResponse>> GetAllDelays();
}


namespace ShopCenter.Infrastructure.ExternalServices.GetDeliveryTime;

public interface IGetDeliveryTimeService
{
    Task<Result<GetDeliveryTimeServiceResponse>> GetNewDeliveryTime();
}

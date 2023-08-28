using Microsoft.Extensions.Options;

namespace ShopCenter.Infrastructure.Services.DelayReportation;
public class GetAllDelaysService: IGetAllDelaysService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppConfig _config;
    public GetAllDelaysService(IUnitOfWork unitOfWork,IOptions<AppConfig> options)
    {
        _unitOfWork = unitOfWork;
        _config = options.Value;
    }

    public async Task<Result<GetAllDelaysResponse>> GetAllDelays()
    {
        var response=new Result<GetAllDelaysResponse>();
        var items=await _unitOfWork.DelayReportRepository.GetListAsync();
        if (items == null)
        {
            response.SetError(new CustomError
            {
                Message = Exceptions.DelayedListNotFound.ToString(),
                Code= Exceptions.DelayedListNotFound.ToDisplay()
            });
        }
        var info = new GetAllDelaysResponse();
        foreach (var item in items)
        {
            info.Items.Add(
                new VendorsWithDelay
                {
                    VendorId = item.Key.VendorId,
                    VendorName = item.Key.VendorName,
                    VendorsDelayTime = item.OrderByDescending(e => e.NewDeliveryTime).Select(e => e.NewDeliveryTime).ToList()
                });

        }
        response.Data = info;
        return response;
    }
}

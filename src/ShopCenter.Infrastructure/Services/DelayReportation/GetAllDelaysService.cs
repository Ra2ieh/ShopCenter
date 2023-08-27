namespace ShopCenter.Infrastructure.Services.DelayReportation;
public class GetAllDelaysService: IGetAllDelaysService
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllDelaysService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<GetAllDelaysResponse>> GetAllDelays()
    {
        var response=new Result<GetAllDelaysResponse>();
        var items=await _unitOfWork.DelayReportRepository.GetListAsync();
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

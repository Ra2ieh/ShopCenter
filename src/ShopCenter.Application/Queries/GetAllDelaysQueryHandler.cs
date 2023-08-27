

namespace ShopCenter.Application.Queries;

public class GetAllDelaysQueryHandler : IRequestHandler<GetAllDelaysQuery, Result<GetAllDelaysResponse>>
{
    private readonly IGetAllDelaysService _getAllDelaysService;
    public GetAllDelaysQueryHandler(IGetAllDelaysService getAllDelaysService)
    {
        _getAllDelaysService = getAllDelaysService;
    }
    public Task<Result<GetAllDelaysResponse>> Handle(GetAllDelaysQuery request, CancellationToken cancellationToken)
    {
        return _getAllDelaysService.GetAllDelays();
    }
}

namespace ShopCenter.Infrastructure.Services.GetDelayQueue;

public class DelayQueueService: IDelayQueueService
{
    private readonly IUnitOfWork _unitOfWork;

    public DelayQueueService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }
    public async Task<Result<GetDelayReportationRequestResponse>> GetDelayReportRequest(int agentId)
    {
        var response = new Result<GetDelayReportationRequestResponse>();
        var requests = await _unitOfWork.DelayQueueRepository.GetListAsync();
        if(!IsAgentAuthenticated(agentId,response)) return response;
        if (!CheckList(response,requests)) return response;
         if(!CanAgentGetRequest(agentId, response, requests)) return response;
        var request = requests.Where(e => e.AgentId == null).FirstOrDefault();
        var order = new GetDelayReportationRequestResponse
        {
            OrderId = request.OrderId,
        };
        await UpdateOrderDelay(agentId, request);
        response.Data = order;
        return response;
    }
    private bool IsAgentAuthenticated(int agentId, Result<GetDelayReportationRequestResponse> response)
    {
         var agentInfo=_unitOfWork.AgentRepository.GetById(agentId);
        if (agentInfo is null)
        {
            response.SetError(new CustomError
            {
                Code = Exceptions.AgentNotFound.ToString(),
                Message = Exceptions.AgentNotFound.ToDisplay()
            });
            return false;
        }
        return true;
    }

    private bool CanAgentGetRequest(int agentId, Result<GetDelayReportationRequestResponse> response, List<DelayQueue> requests)
    {
        if (requests.Any(e => e.AgentId == agentId))
        {
            response.SetError(new CustomError
            {
                Code = Exceptions.NotAllowedToGetDelayReportRequest.ToString(),
                Message = Exceptions.NotAllowedToGetDelayReportRequest.ToDisplay()
            });
            return false;
        }
        return true;
    }

    private bool CheckList( Result<GetDelayReportationRequestResponse> response, List<DelayQueue> requests)
    {
        if (requests is null)
        {
            response.SetError(new CustomError
            {
                Code = Exceptions.DelayedListNotFound.ToString(),
                Message = Exceptions.DelayedListNotFound.ToDisplay()
            });
            return false;
        }
        return true;
    }

    private async Task  UpdateOrderDelay(int agentId, DelayQueue request)
    {

        request.AgentId = agentId;
        await _unitOfWork.DelayQueueRepository.Update(request);
        
    }

}

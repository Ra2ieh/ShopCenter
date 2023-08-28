


namespace ShopCenter.Infrastructure.Repositories;

public class AgentRepository: IAgentRepository
{
    private readonly ShopCenterDbContext _dbContext;
    public AgentRepository(ShopCenterDbContext shopCenterDbContext)
    {
        _dbContext = shopCenterDbContext;
    }

    public Agent GetById(int id)
    {
        return _dbContext.Agent.FirstOrDefault(e => e.AgentId == id);
    }
}

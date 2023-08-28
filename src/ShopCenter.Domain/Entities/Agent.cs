

namespace ShopCenter.Domain.Models;
public class Agent
{
    public int AgentId { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }=String.Empty;
    [MaxLength(20)]
    public string LastName { get; set; }= String.Empty; 
}

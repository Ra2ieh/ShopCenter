

namespace ShopCenter.Domain.EntityConfigurations
{
    public class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasData(new List<Agent>
           {
               new Agent{ AgentId = 10, FirstName = " نام 1", LastName="نام 2"},
               new Agent{ AgentId = 11, FirstName = " نام 2", LastName="نام 2"},
               new Agent{ AgentId = 12, FirstName = " نام 3", LastName="نام 3"},
           });
        }
    }
}

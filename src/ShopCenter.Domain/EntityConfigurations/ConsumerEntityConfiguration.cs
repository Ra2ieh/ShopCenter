

namespace ShopCenter.Domain.EntityConfigurations;

public class ConsumerEntityConfiguration: IEntityTypeConfiguration<Consumer>
{
    public void Configure(EntityTypeBuilder<Consumer> builder)
    {
        builder.HasData(new List<Consumer>
           {
               new Consumer{ ConsumerId = 10, ConsumerName = " نام 1", PhoneNumber="09222772017"},
               new Consumer{ ConsumerId = 11, ConsumerName = " نام 2", PhoneNumber="09222772018"},
           });
    }
}
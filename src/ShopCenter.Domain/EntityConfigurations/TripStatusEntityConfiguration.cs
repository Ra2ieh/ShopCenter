using ShopCenter.Domain.Enums;

namespace ShopCenter.Domain.EntityConfigurations;

public class TripStatusEntityConfiguration : IEntityTypeConfiguration<TripStatus>
{

    public void Configure(EntityTypeBuilder<TripStatus> builder)
    {
        builder.HasData(new List<TripStatus>
        {
            new TripStatus
            {
                TripStatusTitle="ASSIGNED",
                TripStatusId=1,
            },
            new TripStatus
            {
                TripStatusTitle="AT_VENDOR",
                TripStatusId=2,
            },
             new TripStatus
            {
                TripStatusTitle="PICKED",
                TripStatusId=3,
            },
             new TripStatus
            {
                TripStatusTitle="DELIVERED",
                TripStatusId=4,
            },

        });
    }
}

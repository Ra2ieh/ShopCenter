namespace ShopCenter.Domain.EntityConfigurations
{
    public  class VendorEntityConfiguration: IEntityTypeConfiguration<Vendor>
{

    public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasData(new List<Vendor>
        {
            new Vendor
            {
                VendorId=10,VendorName="فروشگاه 1",
            },
            new Vendor
            {
                VendorId=11,VendorName="فروشگاه 2",
            }

        });
        }
    }

}


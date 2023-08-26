﻿namespace ShopCenter.Domain.Models;
public  class Vendor
{
    public int VendorId { get; set; }
    public string VendorName { get; set; } = string.Empty;
    public DateTime ContractDate { get; set; }
    public ICollection<Order> Orders { get; set; }
}

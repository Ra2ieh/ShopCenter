

using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Domain.Enums;

public enum TripStatusEnum
{
    [Display(Name ="ASSIGNED")]
    ASSIGNED=1,
    [Display(Name = "AT_VENDOR")]
    AT_VENDOR =2,
    [Display(Name = "PICKED")]
    PICKED =3,
    [Display(Name = "DELIVERED")]
    DELIVERED =4
}

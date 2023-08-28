namespace ShopCenter.Domain.Enums;

public enum Exceptions
{
    [Display(Name = "خطا در برقراری ارتباط")]
    ServereError ,
    [Display(Name = "سفارش مورد نظر یافت نشد")]
    OrderNotFound,
    [Display(Name = "کاربر گرامی همچنان از زمان انتظار شما باقی مانده است. امکان ثبت تاخیر برای شما فراهم نمی باشد")]
    CanNotReportDelay,
    [Display(Name = "کاربر گرامی درخواست پیگیری شما قبلا ثبت شده و توسط همکاران ما در حال بررسی می باشد.")]
    DuplicateReport,
    [Display(Name = "هیچ فروشگاهی در هفته اخیر تاخیر نداشته است")]
    DelayedListNotFound,
    [Display(Name = "شما دارای درخواست باز می باشید.امکان دریافت درخواست دیگر مجاز نیست")]
    NotAllowedToGetDelayReportRequest,
    [Display(Name = "کد پرسنلی شما یافت نشد")]
    AgentNotFound 
}

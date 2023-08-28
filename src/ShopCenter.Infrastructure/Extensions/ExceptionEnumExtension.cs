

using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Infrastructure.Extensions
{
    public static class EnumExtension
    {
        public static string  ToDisplay(this Enum  value, DisplayProperty property=DisplayProperty.Name)
        {
            if(value==null)
                throw new ArgumentNullException("value");

           DisplayAttribute displayAttribute=value.GetType().GetField(value.ToString())?.GetCustomAttributes<DisplayAttribute>(inherit:false).FirstOrDefault();
            if(displayAttribute==null)
                return value.ToString();
            return (displayAttribute.GetType().GetProperty(property.ToString())?.GetValue(displayAttribute, null)) ?.ToString();
        }
    }
}

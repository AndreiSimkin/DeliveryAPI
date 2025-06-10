using DeliveryDesktop.Extensions;
using System.Windows;
using System.Windows.Data;

namespace DeliveryDesktop.ValueConverters
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enumValue = value as Enum;

            return enumValue == null
                ? DependencyProperty.UnsetValue
                : enumValue.GetDescription();
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

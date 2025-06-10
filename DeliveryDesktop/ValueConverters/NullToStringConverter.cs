using System.Windows;
using System.Windows.Data;

namespace DeliveryDesktop.ValueConverters
{
    public class NullToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
                return value;

            string? placeholderString = parameter as string;

            return placeholderString == null
                ? DependencyProperty.UnsetValue
                : placeholderString;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

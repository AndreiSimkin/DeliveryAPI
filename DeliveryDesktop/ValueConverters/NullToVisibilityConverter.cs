using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DeliveryDesktop.ValueConverters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility nullVisibility = Visibility.Hidden;
            Visibility notNullVisibility = Visibility.Visible;

            if (parameter is string stringisibility)
            {
                Visibility? visibility = StringToVisiblity(stringisibility);

                if (visibility.HasValue)
                    nullVisibility = visibility.Value;
            }

            if (nullVisibility == Visibility.Visible)
                notNullVisibility = Visibility.Hidden;

            return value == null
                ? nullVisibility
                : notNullVisibility;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        private Visibility? StringToVisiblity(string vibilityString)
        {
            return vibilityString switch
            {
                "Visible" => Visibility.Visible,
                "Collapsed" => Visibility.Collapsed,
                "Hidden" => Visibility.Hidden,
                _ => null
            };
        }
    }
}

using System;
using System.Globalization;
using Xamarin.Forms;

namespace EventApp.Converters
{
    public class BoolToColorMessage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                if ((bool)value)
                    return "#C7E7FF";

            return "#E9E9E9";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

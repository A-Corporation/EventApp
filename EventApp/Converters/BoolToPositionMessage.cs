﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace EventApp.Converters
{
    public class BoolToPositionMessage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                if ((bool) value)
                    return new Thickness(80, 10, 10, 10);

            return new Thickness(10, 10, 80, 10);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

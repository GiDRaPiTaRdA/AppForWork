using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace AppForWork2.Converters
{
    public class BoolInvertor:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean && (bool)value)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean && (bool)value)
            {
                return false;
            }
            return true;
        }
    }
}
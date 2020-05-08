using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace WeatherApp
{
    class ValueConventer : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int returnedValue;

            if (int.TryParse((string)value, out returnedValue))
            {
                return returnedValue;
            }

            throw new Exception("The text is not a number");
        }
    }
}
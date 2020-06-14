using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.Model.Converters
{
    
    class HumidityImageConverter : IValueConverter
    {
        //always return same picture, which is humidity
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pack = "pack://application:,,,/WeatherApp;component/Resources/Image/humidity.png";
            return pack;
        }
        //default error
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

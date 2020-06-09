using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.Model.Converters
{
    //interfejs wymaga zaimplementowanie metod Convert i ConverBack, w rzeczywistosci potrzebny jest tylko obiekt value
    class TemperatureImageConverter : IValueConverter
    {
        //always return same picture, which is temp
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pack = "pack://application:,,,/WeatherApp;component/Resources/Image/hot.png";
            return pack;
        }
        //default error
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

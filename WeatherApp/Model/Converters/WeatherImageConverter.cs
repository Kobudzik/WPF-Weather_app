using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WeatherApp.Model.Converters
{

    ///<remarks>interfejs wymaga zaimplementowanie metod Convert i ConverBack, w rzeczywistosci potrzebny jest tylko obiekt value</remarks>
    class WeatherImageConverter : IValueConverter
    {
        /// <summary>
        //w zaleznosci od tego jaki string bedzie zawieral obiekt value, zwroci do 
        //widoku odpowiedni obrazek
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "broken clouds":
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/rain.png";
                case "few clouds":
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/cloudy.png";
                case "scattered clouds":
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/cloudy.png";
                case "clear sky":
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/sunny.png";
                case "overcast clouds":
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/overcast.png";
                default:
                    return "pack://application:,,,/WeatherApp;component/Resources/Image/sunny.png";
            }


        }

        /// <summary>
        ///NOT IMPLEMENTED, not used; usage causes error
        /// </summary>
        /// <param name="value" > value got from vievmodel's model reference</param>
        /// <param name="targetType">forced by interface</param>
        /// <param name="parameter">forced by interface</param>
        /// <param name="culture">forced by interface</param>
        /// <returns>returns picutre of humidity symbol/returns>
        /// 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

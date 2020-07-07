using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace WeatherApp.Model.Converters
{
    ///<remarks> class used to convert humidity image according to its state</remarks>
    class HumidityImageConverter : IValueConverter
    {
        /// <summary>
        ///always return same picture, which is humidity
        /// </summary>
        /// <param name="value" > value got from vievmodel's model reference</param>
        /// <param name="targetType">forced by interface</param>
        /// <param name="parameter">forced by interface</param>
        /// <param name="culture">forced by interface</param>
        /// <returns>returns picutre of humidity symbol/returns>
        /// 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pack = "pack://application:,,,/WeatherApp;component/Resources/Image/humidity.png";
            return pack;
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WeatherApp.ViewModel
{
    ///<remarks> class used to convert view's visibility</remarks>
    class VisibilityConventer : IValueConverter
    {
        
        /// <summary>
        /// converts bool to visibility
        /// </summary>
        /// <param name="value" > value got from vievmodel's model reference</param>
        /// <param name="targetType">forced by interface</param>
        /// <param name="parameter">forced by interface</param>
        /// <param name="culture">forced by interface</param>
        /// <returns> Visibility.Collapsed if true, and .Visible if false</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is bool) && ((bool)value) == true)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

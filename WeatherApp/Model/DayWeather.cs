using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class DayWeather
    {
         double Temperature;
         string Clouds;
         int Humidity;
        
        public DayWeather(double temperature, string clouds, int humidity)
        {
            Temperature = temperature;
            Clouds = clouds;
            Humidity = humidity;
        }

        public override string ToString()
        {
            string result = String.Format("The temerature is equall to '{0}', the clouds are '{1}', and humidity is '{2}'", Temperature, Clouds, Humidity);
            return result;
        }
    }
}

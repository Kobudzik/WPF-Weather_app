using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class DayWeather
    {
        public double Temperature { get; set; }
        public string Clouds { get; set; }
        public int Humidity { get; set; }
        public DateTime Date { get; set; }

        public DayWeather(double temperature, string clouds, int humidity, DateTime date)
        {
            Temperature = temperature;
            Clouds = clouds;
            Humidity = humidity;
            Date = date;
        }

        public override string ToString()
        {
            string result = String.Format("The temerature is equall to '{0}', the clouds are '{1}', and humidity is '{2}'", Temperature, Clouds, Humidity);
            return result;
        }
    }
}

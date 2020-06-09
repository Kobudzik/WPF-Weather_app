using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class DayWeather
    {///<remarks>
     ///After API respond- Weather Getter works to create DayWeather objects. One object is one day
     ///</remarks>
        public double Temperature { get; set; }
        public string Clouds { get; set; }
        public int Humidity { get; set; }
        public string Date { get; set; }


        public DayWeather(double temperature, string clouds, int humidity, DateTime date)
        {
            Temperature = temperature;
            Clouds = clouds;
            Humidity = humidity;
            Date = $"{date.Day.ToString()}/{date.Month.ToString()}/{ date.Year.ToString()}";
        }

        /// <summary>
        /// overrided ToString method- for testing only!
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = String.Format("The temerature is equall to '{0}', the clouds are '{1}', and humidity is '{2}'", Temperature, Clouds, Humidity);
            return result;
        }
    }
}

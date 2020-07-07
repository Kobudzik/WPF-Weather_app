using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    ///<remarks>
    ///After API respond- Weather Getter works to create DayWeather objects. One object is one day
    ///</remarks>
    public class DayWeather
    {
        /// <summary> containing temperature of one day/summary>
        public double Temperature { get; set; }

        /// <summary> containing Clouds of one day/summary>
        public string Clouds { get; set; }

        /// <summary> containing Humidity of one day/summary>
        public int Humidity { get; set; }

        /// <summary> containing Date of one day/summary>
        public string Date { get; set; }



        /// <summary> DayWeather's constructor</summary>
        /// <param name="temperature" >temperature (from API call)</param>
        /// <param name="clouds">clouds (from API call)</param>
        /// <param name="humidity">humidity (from API call) </param>
        /// <param name="date">date (from API call)</param>
        /// <returns> single DayWeather object</returns>
        /// 

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
        /// <returns> Returns string object- text summary of an object</returns>
        public override string ToString()
        {
            string result = String.Format("The temerature is equall to '{0}', the clouds are '{1}', and humidity is '{2}'", Temperature, Clouds, Humidity);
            return result;
        }
    }
}

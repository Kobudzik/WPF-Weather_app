using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WeatherApp.Model;


namespace WeatherApp.ViewModel
{
    class WeatherViewModel
    {
        public WeatherGetter CreatedWeatherGetter { get; set; }

        public WeatherViewModel()
        {
            CreatedWeatherGetter = new WeatherGetter();
        }

        List<DayWeather> daysList = new List<DayWeather>();
      

        public void CreateHTTPRequestURL()
        {
            CreatedWeatherGetter.CreateHTTPRequestURL();            
        }

        public void GetXMLData()
        {
            
            CreatedWeatherGetter.GetXMLData();
                        
        }

        public void PopulateDayWeatherList()
        {
            CreatedWeatherGetter.PopulateDayWeatherList(daysList);            
        }

        public void PrimitiveShow()
        {
            foreach(DayWeather day in daysList)
            {
                MessageBox.Show(day.ToString());
            }
        }



    }
}

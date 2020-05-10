using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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


        public ObservableCollection<DayWeather> daysObservableCollection;//te dane musimy odświeżac




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
            if (daysObservableCollection != null)
                daysObservableCollection.Clear();

            if (!CreatedWeatherGetter.errorOccured)
            {
                daysObservableCollection = new ObservableCollection<DayWeather>(CreatedWeatherGetter.PopulateDayWeatherList());
            }
            
        }
    }
}

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
        /// <remarks>
        /// Provides communication between view and model
        /// </remarks>
      
        ///<summary>
        ///holds model's WeatherGetter reference
        ///</summary>
        public WeatherGetter CreatedWeatherGetter { get; set; }

        /// <summary>
        /// Constructor- creates new WeatherGetter model object
        /// </summary>
        public WeatherViewModel()
        {
            CreatedWeatherGetter = new WeatherGetter();
        }

        /// <summary>
        /// Using ViewModel's reference to model sets city property
        /// </summary>
        /// <param name="city"></param>
        public void SetCity(string city)
        {
            CreatedWeatherGetter.City = city;
        }

        /// <summary>
        /// Using ViewModel's reference to model sets days property
        /// </summary>
        public void SetDays(string days)
        {
            CreatedWeatherGetter.Days = days;
        }

        /// <summary>
        /// Object that user will see in view's list view
        /// </summary>
        public ObservableCollection<DayWeather> daysObservableCollection;//te dane musimy odświeżac


        /// <summary>
        /// Using ViewModel's reference to model- restores default app state
        /// </summary>
        public void Reset()
        {
            CreatedWeatherGetter.Reset();
        }

        /// <summary>
        /// Using ViewModel's reference to model- generates API request
        /// </summary>
        public void CreateHTTPRequestURL()
        {
            CreatedWeatherGetter.CreateHTTPRequestURL();
        }

        /// <summary>
        /// Using ViewModel's reference to model- creates XML data from api html response
        /// </summary>
        public void GetXMLData()
        {

            CreatedWeatherGetter.GetXMLData();

        }

        /// <summary>
        /// If exists- generates collection for user from day weather objects
        /// </summary>
        public void PopulateDayWeatherList()
        {
            if (daysObservableCollection != null)
                daysObservableCollection.Clear();

            if (!CreatedWeatherGetter.ErrorOccured)
            {
                try
                {
                    daysObservableCollection = new ObservableCollection<DayWeather>(CreatedWeatherGetter.PopulateDayWeatherList());
                }
                catch (Exception e)
                {
                    MessageBox.Show("VIEWMODEL: " + e.Message);
                }
            }            
        }
        /// <summary>
        /// Using ViewModel's reference to model writes returned location to let user know what hes seeing
        /// </summary>
        public void GetReturnedLocation()
        {
            CreatedWeatherGetter.GetReturnedLocation();
        }

    }
}

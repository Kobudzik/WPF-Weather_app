using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WeatherApp.Model;



namespace WeatherApp.ViewModel
{
    /// <remarks>
    /// Provides communication between view and model
    /// </remarks>
    class WeatherViewModel : INotifyPropertyChanged
    {


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
        /// <param name="city"> City that user entered</param>
        public void SetCity(string city)
        {
            CreatedWeatherGetter.City = city;

        }

        /// <summary>
        /// Using ViewModel's reference to model sets days property
        /// </summary>
        /// <param name="days">Days that user entered</param>
        public void SetDays(string days)
        {
            CreatedWeatherGetter.Days = days;
        }

        /// <summary>
        /// Object that user will see in view's list view
        /// </summary>
        public ObservableCollection<DayWeather> daysObservableCollection;//te dane musimy odświeżac

        /// <summary>
        /// private backing field- first object that will be bigger than the rest
        /// </summary>
        private DayWeather _firstDay;

        /// <summary>
        /// public Property- first object that will be bigger than the rest; setting fires of OnPropertyChanged event
        /// </summary>
        public DayWeather FirstDay
        {
            get { return _firstDay; }
            set
            {
                _firstDay = value;
                OnPropertyChanged(nameof(FirstDay));
            }
        }


        /// <summary>
        /// Using ViewModel's reference to model- restores default app state
        /// </summary>
        public void Reset()
        {
            CreatedWeatherGetter.Reset();
            //FirstDay = null;//need to be fixed in future
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
            {
                daysObservableCollection.Clear();
                FirstDay = null;
            }

            if (!CreatedWeatherGetter.ErrorOccured)
            {
                try
                {
                    daysObservableCollection = new ObservableCollection<DayWeather>(CreatedWeatherGetter.PopulateDayWeatherList());
                    FirstDay = daysObservableCollection.FirstOrDefault();
                    daysObservableCollection.RemoveAt(0);
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


        /// <summary>
        /// Used for data refreshing
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
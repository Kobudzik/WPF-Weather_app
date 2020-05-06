using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        
            string url = WeatherGetter.CreateHTTPRequestURL("Tuchow", 2);
            XDocument xdoc = WeatherGetter.GetXMLData(url);






            StringBuilder result = new StringBuilder();

            var days =
                from day
                in xdoc.Descendants("time")
                select new
                {
                    TemperatureValue = day.Element("temperature").Attribute("value").Value,
                    Clouds = day.Element("clouds").Attribute("value").Value,
                    Humidity = day.Element("humidity").Attribute("value").Value
                };

            List<DayWeather> daysList = new List<DayWeather>();

            //int curDay = 0;

            foreach (var day in days)
            {
                daysList.Add(new DayWeather
                    (
                    Convert.ToDouble(day.TemperatureValue, System.Globalization.CultureInfo.InvariantCulture),
                    day.Clouds,
                    Convert.ToInt32(day.Humidity, System.Globalization.CultureInfo.InvariantCulture)));

            }

            foreach (DayWeather day in daysList)
                result.AppendLine(day.ToString() + "\n");



            myTextBox.Text = result.ToString();





        }

    }
}

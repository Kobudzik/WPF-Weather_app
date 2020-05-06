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
            string html = string.Empty;
            string url = @"http://api.openweathermap.org/data/2.5/forecast?q=Tuchow&mode=xml&appid=2517431d46cd54e4f965409583890e1c&cnt=2&units=metric";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }



            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(html);

            StringBuilder result = new StringBuilder();


            var days =
                from day
                in xdoc.Descendants("time")
                select new
                {
                    TemperatureValue = day.Element("temperature").Attribute("value").Value,
                    TemperatureUnit = day.Element("temperature").Attribute("unit").Value
                };
            int curDay = 0;
            foreach (var day in days)
            {
                result.AppendFormat("Day: {0} \n", curDay);
                result.AppendLine(day.ToString());
                curDay++;
            }

            myTextBox.Text = result.ToString();



        }

    }
}

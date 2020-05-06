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
    class WeatherGetter
        //facade
    {
        public static string CreateHTTPRequestURL(string city, int days)
        {
            string result= string.Format(@"http://api.openweathermap.org/data/2.5/forecast?q="+ city + "&mode=xml&appid=2517431d46cd54e4f965409583890e1c&cnt=" + days + "&units=metric");
            return result;
        }


        public static XDocument GetXMLData(string URL)
        {
            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(html);

            return xdoc;
        }

    }
}

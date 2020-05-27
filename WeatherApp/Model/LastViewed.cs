using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class LastViewed
    {
        public List<string> lastViewedInSession = new List<string>();

        public void checkViewed(bool error, string city )
        {
            if(error==false && !lastViewedInSession.Contains(city) && lastViewedInSession.Count<20)
            {
                lastViewedInSession.Add(city);
            }
        }
    }
}

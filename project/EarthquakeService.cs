
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace project
{
    public class EarthquakeEventArgs:EventArgs
    {
        public EarthquakeEventArgs(List<Earthquake> locations)
        {
            Locations = locations;
        }
        public List<Earthquake> Locations { get; set; }
    }
    public class EarthquakeService
    {
        public static void GetRecentEarthquakes(EventHandler<EarthquakeEventArgs> callback)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += (o, e) =>
            {
                XDocument doc = XDocument.Load(e.Result);
                var data = (from eq in doc.Element("rss").Element("channel").Elements("item")
                            select new Earthquake()
                            {
                                Title = eq.Element("title").Value,
                                Description = eq.Element("description").Value,
                                location = new Location(Convert.ToDouble(eq.Element(XName.Get("lat", "http://www.w3.org/2003/01/geo/wgs84_pos#")).Value), Convert.ToDouble(eq.Element(XName.Get("long", "http://www.w3.org/2003/01/geo/wgs84_pos#")).Value))
                            }).ToList();

                callback(null, new EarthquakeEventArgs(data));
            };
            client.OpenReadAsync(new Uri("http://earthquake.usgs.gov/eqcenter/recenteqsww/catalogs/eqs7day-M2.5.xml"));
        }
    }
}
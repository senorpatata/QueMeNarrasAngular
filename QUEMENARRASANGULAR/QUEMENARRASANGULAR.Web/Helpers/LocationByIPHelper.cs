using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace QUEMENARRASANGULAR.Web.Helpers
{
    public static class LocationByIPHelper
    {

        public static Location GeoLocate()
        {
            var API_KEY = System.Configuration.ConfigurationManager.AppSettings["GEOLOCATIONAPIKEY"].ToString();

            string ip = HttpContext.Current.Request.UserHostAddress;
            var url = "http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=xml";

            var defaultLocation = GetValenciaLocation();
            try
            {
                var doc = System.Xml.Linq.XDocument.Load(string.Format(url, API_KEY, ip));
                var longitude = double.Parse(doc.Descendants("longitude").First().Value, CultureInfo.InvariantCulture);
                var latitude = double.Parse(doc.Descendants("latitude").First().Value, CultureInfo.InvariantCulture);


                if (longitude != 0 || latitude != 0)
                {
                    defaultLocation =  new Location
                    {
                        Latitude = latitude,
                        Longitude = longitude
                    };
                }

                
            }
            catch(Exception ex)
            {
                //usualmente prohibido
            }

            return defaultLocation;
           
        }

        private static Location GetValenciaLocation()
        {
            return new Location { Longitude = -0.3763936000000285, Latitude = 39.4707127 };
        }

        public class Location
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
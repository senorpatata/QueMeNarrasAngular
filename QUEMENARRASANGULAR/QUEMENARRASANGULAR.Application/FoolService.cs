using Abp.UI;
using LinqToTwitter;
using LinqToTwitter.Common;
using LinqToTwitter.Net;
using LinqToTwitter.Security;
using QUEMENARRASANGULAR.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QUEMENARRASANGULAR
{
    public class FoolService : QUEMENARRASANGULARAppServiceBase, IFoolService
    {


        private IList<PlaceInfo> GetPlaces(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {
            var listaPlaces = new List<PlaceInfo>();


            try
            {
                var results = context.Geo.Where(x => x.Latitude == latitude && x.Longitude == longitude && x.Type == GeoType.Search).ToList();


                foreach (var result in results)
                {
                    foreach (var place in result.Places)
                    {
                        listaPlaces.Add(new PlaceInfo() { Name = place.Name, Url = place.Url });
                       
                    }

                }
            }
            catch (Exception exception)
            {
                listaPlaces.Add(new PlaceInfo() { Name = exception.ToString(), Url = "# " });
            }
            return listaPlaces;
        }


        private IList<HashInfo> GetHashTags(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {
            var listaTags = new List<HashInfo>();
          

            try
            {
                //Debería funcionar, pero hasta en los ejemplos no va
                //var trends = context.Trends.Where(x => x.Latitude == latitude && x.Longitude == longitude && x.Type == TrendType.Closest).SingleOrDefault();
                var trends = context.Trends.Where(x => x.Type == TrendType.Available).SingleOrDefault();

                foreach (var loca in trends.Locations)
                {
                    var trendsdeloca = context.Trends.Where(x => x.Type == TrendType.Place && x.WoeID == loca.WoeID ).ToList();
                    
                    foreach(var trend in trendsdeloca)
                    {
                        listaTags.Add(new HashInfo() { Name = trend.Name, Url = trend.SearchUrl, Volume = trend.TweetVolume });
                    }
               
                }
            }
            catch (Exception exception)
            {
                //EXCEPCIÓN POR RATE LIMIT
                listaTags.Add(new HashInfo() { Name = exception.ToString(), Url = "# " });
            }
            
            if(listaTags.Count > 10)
            {
                listaTags = listaTags.OrderByDescending(x => x.Volume).ToList().Take(10).ToList();
            }
            return listaTags;
        }

      


        private IList<TuitInfo> GetTuits(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {
            var search = context.Search.Where(x => x.GeoCode == string.Format("{0},{1},{2}mi",latitude.ToString().Replace(",","."),longitude.ToString().Replace(",", "."), zoomLevel) && x.Type == SearchType.Search &&  x.Query == "valencia").FirstOrDefault();

            foreach(var status in search.Statuses)
            {
            
                TuitInfo tuid = new TuitInfo();
                tuid.Latitude = status.Coordinates.Latitude;
                tuid.Longitude = status.Coordinates.Longitude;
                //tuid.TweetUrl = statu
                //tuid.TweetCabecera = "Random tuit " + i;
                //tuid.Id = i;
                //lista.Add(tuid);
            }

            var lista = new List<TuitInfo>();
       
            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                double randovalue = (random.NextDouble() * 2.0) - 1.0;
                TuitInfo tuid = new TuitInfo();
                tuid.Latitude = latitude + randovalue * 0.1;
                tuid.Longitude = longitude + randovalue * 0.1;
                tuid.TweetUrl = "https://twitter.com/spain/status/748979527628488706";
                tuid.TweetCabecera = "Random tuit " + i;
                tuid.Id = i;
                lista.Add(tuid);
            }

            return lista;

        }
        public InformationDto GetInformation(double longitude, double latitude, int zoomLevel)
        {
            var dto = new InformationDto();

            var context = TwitterHelper.GetTuiterContext();

            /*Obtener */
            dto.Tuits = GetTuits(context, longitude, latitude, zoomLevel);
            dto.HashTags = GetHashTags(context, longitude, latitude, zoomLevel);
            dto.Places = GetPlaces(context,longitude, latitude, zoomLevel);
            return dto;
        }

    }


    public class TwitterHelper
    {
        public static TwitterContext GetTuiterContext()
        {
            IAuthorizer auth = DoSingleUserAuth();

            var taskAuth = auth.AuthorizeAsync();
            taskAuth.Wait();

            var twitterCtx = new TwitterContext(auth);
            return twitterCtx;
        }


        static IAuthorizer DoApplicationOnlyAuth()
        {
            var auth = new ApplicationOnlyAuthorizer()
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerKey],
                    ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerSecret]
                },
            };

            return auth;
        }

        static IAuthorizer DoSingleUserAuth()
        {
            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new SingleUserInMemoryCredentialStore
                {
                    ConsumerKey = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerKey],
                    ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerSecret],
                    AccessToken = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterAccessToken],
                    AccessTokenSecret = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterAccessTokenSecret]
                }
            };

            return auth;
        }

        static IAuthorizer DoXAuth()
        {
            var auth = new XAuthAuthorizer
            {
                CredentialStore = new XAuthCredentials
                {
                    ConsumerKey = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerKey],
                    ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings[OAuthKeys.TwitterConsumerSecret],
                    UserName = "candumaru  ",
                    Password = "YourPassword"
                }
            };

            return auth;
        }
    }

}

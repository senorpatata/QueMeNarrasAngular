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


        private IList<string> GetPlaces(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {
            var listaTags = new List<string>();


            try
            {
                var results = context.Geo.Where(x => x.Latitude == latitude && x.Longitude == longitude && x.Type == GeoType.Search).ToList();


                foreach (var result in results)
                {
                    foreach (var place in result.Places)
                    {
                        listaTags.Add(place.Name);

                    }

                }
            }
            catch (Exception ex)
            {
                //la la laaaa
            }
            return listaTags;
        }


        private IList<string> GetHashTags(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {
            var listaTags = new List<string>();
            listaTags.Add("respect");
            listaTags.Add("bro");


            try
            {
                // var trends = context.Trends.Where(x => x.Latitude == latitude && x.Longitude == longitude && x.Type == TrendType.Closest).SingleOrDefault();

                var trends = context.Trends.Where(x => x.Type == TrendType.Available).SingleOrDefault();

                foreach (var tren in trends.Locations)
                {
                    listaTags.Add(tren.Name);
                }
            }
            catch (Exception)
            {
            }

            return listaTags;
        }

       


        private IList<InformationTuitDto> GetTuits(TwitterContext context, double longitude, double latitude, int zoomLevel)
        {

            var lista = new List<InformationTuitDto>();
            Random random = new Random();

            for (int i = 0; i < 30; i++)
            {
                double randovalue = (random.NextDouble() * 2.0) - 1.0;
                InformationTuitDto tuid = new InformationTuitDto();
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
            //  dto.Places = GetPlaces(context,longitude, latitude, zoomLevel);
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

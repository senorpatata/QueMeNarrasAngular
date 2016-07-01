using Abp.UI;
using QUEMENARRASANGULAR.Dto;
using System;
using System.Collections.Generic;

namespace QUEMENARRASANGULAR
{
    public class FoolService : QUEMENARRASANGULARAppServiceBase, IFoolService
    {

        public bool Foolazo()
        {
            return true;
        }

        public string[] GetDatosMain()
        {
            var infoPeticion = string.Format("GetDatosMain");
            try
            {
                var datosMain = new string[]{ "uno", "dos" };
                return datosMain;
            }
            catch (UserFriendlyException ex)
            {
                Logger.Error("Error controlado en " + infoPeticion, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                //Inesperado
                Logger.Error("Error no controlado " + infoPeticion, ex);
                throw ex;
            }
        }

        private IList<string> GetHashTags(double longitude, double latitude, int zoomLevel)
        {
            var listaTags = new List<string>();
            listaTags.Add("respect");
            listaTags.Add("bro");

            return listaTags;
        }

        private IList<InformationTuitDto> GetTuits(double longitude, double latitude, int zoomLevel)
        {

            var lista = new List<InformationTuitDto>();
            Random random = new Random();
     
            for (int i = 0; i < 30; i++)
            {
                double mantissa = (random.NextDouble() * 2.0) - 1.0;
                InformationTuitDto tuid = new InformationTuitDto();
                tuid.Latitude = latitude + mantissa;
                tuid.Longitude = longitude + mantissa;
                tuid.TweetUrl = "https://twitter.com/spain/status/748979527628488706";
                tuid.TweetCabecera = "Random tuit " + i;

                lista.Add(tuid);
            }

            return lista;

        }
        public InformationDto GetInformation(double longitude, double latitude, int zoomLevel)
        {
            var dto = new InformationDto();

            /*Obtener */
            dto.Tuits = GetTuits(longitude,latitude,zoomLevel);
            dto.HashTags = GetHashTags(longitude, latitude, zoomLevel);
            return dto;
        }

    }
}

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

        public IList<InformationTuitDto> GetTuits(double latitude, double longitude, int zoomLevel)
        {

            var lista = new List<InformationTuitDto>();


            /*Obtener */

            return lista;
        }

    }
}

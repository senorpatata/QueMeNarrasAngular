using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.UI;


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

    }
}

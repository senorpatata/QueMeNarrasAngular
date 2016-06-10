using Abp.Web.Mvc.Controllers;

namespace QUEMENARRASANGULAR.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class QUEMENARRASANGULARControllerBase : AbpController
    {
        protected QUEMENARRASANGULARControllerBase()
        {
            LocalizationSourceName = QUEMENARRASANGULARConsts.LocalizationSourceName;
        }
    }
}
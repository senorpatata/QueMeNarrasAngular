using Abp.Application.Services;

namespace QUEMENARRASANGULAR
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class QUEMENARRASANGULARAppServiceBase : ApplicationService
    {
        protected QUEMENARRASANGULARAppServiceBase()
        {
            LocalizationSourceName = QUEMENARRASANGULARConsts.LocalizationSourceName;
        }
    }
}
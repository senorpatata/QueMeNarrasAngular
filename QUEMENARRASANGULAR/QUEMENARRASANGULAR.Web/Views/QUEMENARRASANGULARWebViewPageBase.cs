using Abp.Web.Mvc.Views;

namespace QUEMENARRASANGULAR.Web.Views
{
    public abstract class QUEMENARRASANGULARWebViewPageBase : QUEMENARRASANGULARWebViewPageBase<dynamic>
    {

    }

    public abstract class QUEMENARRASANGULARWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected QUEMENARRASANGULARWebViewPageBase()
        {
            LocalizationSourceName = QUEMENARRASANGULARConsts.LocalizationSourceName;
        }
    }
}
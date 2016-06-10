using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace QUEMENARRASANGULAR
{
    [DependsOn(typeof(AbpWebApiModule), typeof(QUEMENARRASANGULARApplicationModule))]
    public class QUEMENARRASANGULARWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(QUEMENARRASANGULARApplicationModule).Assembly, "app")
                .Build();
        }
    }
}

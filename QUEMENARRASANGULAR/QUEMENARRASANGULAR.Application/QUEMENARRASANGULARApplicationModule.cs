using System.Reflection;
using Abp.Modules;

namespace QUEMENARRASANGULAR
{
    [DependsOn(typeof(QUEMENARRASANGULARCoreModule))]
    public class QUEMENARRASANGULARApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
 
        }
    }
}

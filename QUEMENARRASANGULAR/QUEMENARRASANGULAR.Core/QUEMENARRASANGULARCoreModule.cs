using System.Reflection;
using Abp.Modules;

namespace QUEMENARRASANGULAR
{
    public class QUEMENARRASANGULARCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

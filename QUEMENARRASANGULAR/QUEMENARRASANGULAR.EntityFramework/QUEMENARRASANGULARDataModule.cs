using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using QUEMENARRASANGULAR.EntityFramework;

namespace QUEMENARRASANGULAR
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(QUEMENARRASANGULARCoreModule))]
    public class QUEMENARRASANGULARDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<QUEMENARRASANGULARDbContext>(null);
        }
    }
}

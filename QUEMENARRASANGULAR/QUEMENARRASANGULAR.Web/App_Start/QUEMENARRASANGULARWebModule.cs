using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Application.Services;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace QUEMENARRASANGULAR.Web
{
    [DependsOn(
        typeof(AbpWebMvcModule),
        typeof(QUEMENARRASANGULARDataModule), 
        typeof(QUEMENARRASANGULARApplicationModule), 
        typeof(QUEMENARRASANGULARWebApiModule))]
    public class QUEMENARRASANGULARWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en-GB", "EN", "famfamfam-flag-gb", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("es-ES", "ES", "famfamfam-flag-es", false));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    QUEMENARRASANGULARConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath("~/Localization/QUEMENARRASANGULAR")
                        )
                    )
                );

  

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<QUEMENARRASANGULARNavigationProvider>();
        }

  

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //RegistrarAPI();
        }

        private static void RegistrarAPI()
        {
            DynamicApiControllerBuilder.For<IFoolService>("app/foolService").Build();

           // var a = DynamicApiControllerBuilder
           //.ForAll<IApplicationService>(typeof(QUEMENARRASANGULARApplicationModule).Assembly, "app");

            
           //a.Build();
        }
    }
}

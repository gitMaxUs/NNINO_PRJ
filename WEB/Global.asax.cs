using AutoMapper;
using BL.Util;
//using Ninject;
//using Ninject.Modules;
//using Ninject.Web.Mvc;
//using Ninject.Web.WebApi;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WEB.UTIL;
using WEB_NNINO_2.UTIL;

namespace WEB
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //AutoMapper Initialize for BLL project
            Mapper.Initialize(cfg =>
            {
              //  UTIL.AutoMapperConfig.Configure(cfg);
               AutoMapperConfigPL.Configure(cfg);
            });

            //NinjectModule utilModulePL = new NinjectRegistrations();
            //NinjectModule serviceModuleBL = new ServiceModule("DefaultConnection");//connectionString
            //var kernel = new StandardKernel(utilModulePL, serviceModuleBL);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

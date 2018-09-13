using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExaltedHelper.Repository.Seed.Interface;
using ExaltedHelper.RestService;

namespace ExaltedHelper.Restservice
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
            var seedBusiness = NinjectWebCommon.GetConcreteImplementation<ISeedManager>();
            seedBusiness.Seed();
        }
    }
}

using CanturkFramework.Core.Utilities.Mvc.Infrastructure;
using CanturkFramework.Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcProject.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule()));
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

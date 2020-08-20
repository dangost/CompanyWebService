using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Modules;
using Ninject;
using WebService.DI;

namespace WebService
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

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            var ninjectResolver = new NinjectDependencyResolver(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver;
        }
    }

}

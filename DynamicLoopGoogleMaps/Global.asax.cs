﻿using System.Web.Mvc;
using System.Web.Routing;
using DynamicLoopGoogleMaps.DataGenerator;
using DynamicLoopGoogleMaps.IoC;
using DynamicLoopGoogleMaps.Models.Mapping;
using StructureMap;

namespace DynamicLoopGoogleMaps
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ContainerBootStrap.Bootstrap();
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            AutoMapperConfiguration.Configure();
            var dataGenerator = (Generator)ObjectFactory.GetInstance(typeof(Generator));
            dataGenerator.Generate();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
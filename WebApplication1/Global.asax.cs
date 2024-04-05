using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WebApplication1.App_Start;
using System.Web.Optimization;
using AutoMapper;
using WebApplication1.Models.User;
using WebAplication.Domains.Entities.User;
using WebAplication.Domain.Entities.User;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           BundelConfig.RegisterBundles(BundleTable.Bundles);
           InitializeAutoMapper();
        }

        protected static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UserLogin, ULoginData>();
                cfg.CreateMap<UserTable, UserMinimal>();
            });
        }
    }
}
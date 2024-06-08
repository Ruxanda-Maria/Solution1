using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using AutoMapper;
using WebApplication1.Web.Models;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Models;
using WebApplication1.Domain.Entities.Admin;


namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
           BundleConfig.RegisterBundles(BundleTable.Bundles);
           InitializeAutoMapper();
        }

          protected static void InitializeAutoMapper()
          {
               Mapper.Initialize(cfg =>
               {
                    cfg.CreateMap<UserLogin, ULoginData>();
                    cfg.CreateMap<UserRegister, URegisterData>();
                    cfg.CreateMap<UDbTable, UserMinimal>();

                    cfg.CreateMap<AddUser, AddUserData>();
                    cfg.CreateMap<AddProduct, AddProductData>();

                    cfg.CreateMap<EditProduct, EditProductData>();
               });
          }
     }
}
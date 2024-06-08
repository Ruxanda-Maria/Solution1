using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.BusinessLogic;
using WebApplication1.Controllers;
using WebApplication1.Extencion;
using WebApplication1.Models;
using WebApplication1.Domain.Entities.User;
using WebApplication1.BusinessLogic.DBModel;
using AutoMapper;

namespace WebApplication1.Web.Controllers
{
    public class HomeController : BaseController
     {
          private readonly ISession _session;
          public HomeController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }
          public void GetCurrentUserAndStatus()
          {
               SessionStatus();
               var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
               string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
               if (userStatus != "guest")
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    ViewBag.user = profile;
               }
               ViewBag.userStatus = userStatus;
          }
          public ActionResult Index()
        {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    List<Product> productsList = db.Products.OrderByDescending(p => p.Bought).Take(8).ToList();
                    ViewBag.productsList = productsList;
               }
               return View();
        }

        public ActionResult Checkout()
        {
               GetCurrentUserAndStatus();
               return View();
        }


        public ActionResult Shop(string type, string category, decimal minPrice, decimal maxPrice, string size)
        {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    List<Product> productsList = db.Products.ToList();
                    if (type != "All")
                    {
                         if (type == "Rochii")
                         {
                              productsList = db.Products.Where(p => p.Type == "Rochie Mireasa" || p.Type == "Rechie Domnisoara").ToList();
                         }
                         else
                         {
                              productsList = db.Products.Where(p => p.Type == type).ToList();
                         }
                    }
                    else if(category != "All")
                    {
                         productsList = db.Products.Where(p => p.Category == category).ToList();
                    }
                    else if(maxPrice != 0)
                    {
                         productsList = db.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
                    }
                    else if(size != "All")
                    {
                         switch (size)
                         {
                              case "XS":
                                   productsList = db.Products.Where(p => p.XS == true).ToList();
                                   break;
                              case "S":
                                   productsList = db.Products.Where(p => p.S == true).ToList();
                                   break;
                              case "M":
                                   productsList = db.Products.Where(p => p.M == true).ToList();
                                   break;
                              case "L":
                                   productsList = db.Products.Where(p => p.L == true).ToList();
                                   break;
                              case "XL":
                                   productsList = db.Products.Where(p => p.XL == true).ToList();
                                   break;
                         }
                    }
                    ViewBag.productsList = productsList;
               }
               return View();
        }

        public ActionResult ShopDetails(int id)
        {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    var product = db.Products.FirstOrDefault(u => u.Id == id);
                    var productsList = db.Products.Where(u => u.Type == product.Type).Take(4).ToList();
                    ViewBag.productsList = productsList;
                    ViewBag.product = product;
               }
               return View();
        }

        public ActionResult Cart()
        {
               GetCurrentUserAndStatus();
               return View();
        }

          public ActionResult BlogDetails()
          {
               GetCurrentUserAndStatus();
               return View();
          }

          public ActionResult Blog()
          {
               GetCurrentUserAndStatus();
               return View();
          }

          public ActionResult About()
          {
               GetCurrentUserAndStatus();
               return View();
          }

          public ActionResult Contacts()
          {
               GetCurrentUserAndStatus();
               return View();
          }
     }
}
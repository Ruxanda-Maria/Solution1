using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BussinessLogic.DBModel;
using WebApplication1.BussinessLogic.Interface;
using WebApplication1.BussinessLogic;
using WebApplication1.Domain.Entities.Product;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new BusinessLogic();
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
    }
}
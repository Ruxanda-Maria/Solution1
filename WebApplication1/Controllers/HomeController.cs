using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Pages_login", "Login");
            }
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Carousel()
        {
            return View();
        }

        public ActionResult Companies()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Portles()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Email_Compose()
        {
            return View();
        }

        public ActionResult Email_Billing()
        {
            return View();
        }

        public ActionResult Email_Action()
        {
            return View();
        }

        public ActionResult Pages_lock_screen()
        {
            return View();
        }

        public ActionResult Pages_recoverpw()
        {
            return View();
        }
    }
}
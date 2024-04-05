using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Attributes;

namespace WebApplication1.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        [AdminMode]
        public ActionResult Index()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
            {
                return RedirectToAction("Pages_login", "Login");
            }
            return View();
        }
    }
}
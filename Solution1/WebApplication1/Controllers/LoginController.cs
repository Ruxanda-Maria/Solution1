using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebApplication1.BussinessLogic.Interface;
using WebApplication1.BussinessLogic;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ISession _session;
        public LoginController()
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

        // GET: Login
        public ActionResult Index()
        {
            GetCurrentUserAndStatus();
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin login)
        {
            var data = Mapper.Map<ULoginData>(login);

            data.LoginIP = Request.UserHostAddress;
            data.LoginDateTime = DateTime.Now;

            var userLogin = _session.UserLogin(data);
            if (userLogin.Status)
            {
                HttpCookie cookie = _session.GenCookie(login.Username);
                ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", userLogin.StatusMsg);
                return View();
            }
        }
    }
}
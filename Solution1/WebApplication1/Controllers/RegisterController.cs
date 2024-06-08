using WebApplication1.BusinessLogic;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RegisterController : BaseController
     {
          private readonly ISession _session;
          public RegisterController()
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<URegisterData>(register);

                data.LoginIP = Request.UserHostAddress;
                data.LoginDateTime = DateTime.Now;

                var userRegister = _session.UserRegister(data);
                if (userRegister.Status)
                {
                    HttpCookie cookie = _session.GenCookie(register.Username);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}
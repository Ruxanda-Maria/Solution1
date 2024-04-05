using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using WebAplication.BusinessLogics;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _sesion;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _sesion = bl.GetLoginBL();

        }

        public ActionResult Pages_login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pages_login(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<ULoginData>(login);

                data.LoginIP = Request.UserHostAddress;
                data.LoginDataTime = DateTime.Now;

                var userLogin = _sesion.UserLoginAction(data);
                if (userLogin.IsSuccess)
                {
                    //HttpCookie cookie = _session.GenCookie(login.Email);
                    //ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.Status);
                    return View();
                }
            }
            return View();
        }
    }
}
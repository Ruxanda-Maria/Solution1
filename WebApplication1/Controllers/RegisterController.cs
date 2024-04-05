using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebAplication.BusinessLogics;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domain.Entities.User;
using WebApplication1.Models.User;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        private readonly ILogin _session;
        public RegisterController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetLoginBL();
        }
        public ActionResult Pages_register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pages_register(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var data = Mapper.Map<URegisterData>(register);

                data.LoginIP = Request.UserHostAddress;
                data.LoginDataTime = DateTime.Now;

                var userRegister = _session.UserRegisterAction(data);
                if (userRegister.IsSuccess)
                {
                    //HttpCookie cookie = _session.GenCookie(register.Email);
                    //ControllerContext.HttpContext.Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.Status);
                    return View();
                }
            }
            return View();
        }
    }
}
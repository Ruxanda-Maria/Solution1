using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAplication.BusinessLogics;
using WebAplication.BusinessLogics.Interface;
using WebAplication.Domain.Entities.User;
using WebAplication.Domain.Enums;
using WebApplication1.Extensions;

namespace WebApplication1.Attributes
{
    public class AdminModeAttribute : ActionFilterAttribute
    {
        private readonly ILogin _sessionBusinessLogic;
        public AdminModeAttribute()
        {
            var businessLogic = new BussinesLogic();
            _sessionBusinessLogic = businessLogic.GetLoginBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiCookie = HttpContext.Current.Request.Cookies["X-KEY"];
            if (apiCookie != null)
            {
                var profile = _sessionBusinessLogic.GetUserByCookie(apiCookie.Value);
                if (profile != null && profile.Level == URole.Admin)
                {
                    HttpContext.Current.SetMySessionObject(profile);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}
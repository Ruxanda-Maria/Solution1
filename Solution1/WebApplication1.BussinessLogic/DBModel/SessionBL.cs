using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.BussinessLogic.Core;
using WebApplication1.BussinessLogic.Interface;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BussinessLogic.DBModel
{
    public class SessionBL
    {
        public class SessionBL : UserApi, ISession
        {
            public HttpCookie GenCookie(string loginCredential)
            {
                return Cookie(loginCredential);
            }

            public BoolResp UserLogin(ULoginData data)
            {
                return UserLoginAction(data);
            }

            public BoolResp UserRegister(URegisterData data)
            {
                return UserRegisterAction(data);
            }

            public UserMinimal GetUserByCookie(string apiCookieValue)
            {
                return UserCookie(apiCookieValue);
            }
        }
    }
}

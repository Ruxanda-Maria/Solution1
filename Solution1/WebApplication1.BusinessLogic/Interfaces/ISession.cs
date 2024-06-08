using WebApplication1.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.BusinessLogic.Interfaces
{
    public interface ISession
    {
        BoolResp UserLogin(ULoginData data);
        BoolResp UserRegister(URegisterData data);
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
    }
}

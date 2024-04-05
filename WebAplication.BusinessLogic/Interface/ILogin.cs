using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domain.Entities.Response;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Interface
{
    public interface ILogin
    {
        ULoginResp UserLoginAction(ULoginData data);
        URegisterResp UserRegisterAction(URegisterData data);
    }
}
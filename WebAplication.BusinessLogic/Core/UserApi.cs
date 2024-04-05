using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogic.AppBL;
using WebAplication.Domain.Entities.User;
using WebAplication.Domains.Entities.Response;
using WebAplication.Domains.Entities.User;

namespace WebAplication.BusinessLogics.Core
{
    public class UserApi
    {
        public ULoginResp RLoginUPService(ULoginData data)
        {

            UserTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                //var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
                }

                if (result == null)
                {
                    return new ULoginResp { IsSuccess = false, Status = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIP;
                    result.LastLogin = data.LoginDataTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }
                return new ULoginResp { IsSuccess = true };
            }
            else
                return new ULoginResp { IsSuccess = false };
        }
    }
}
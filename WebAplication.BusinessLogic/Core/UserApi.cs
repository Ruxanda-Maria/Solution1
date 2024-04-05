using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.BusinessLogic.AppBL;
using WebAplication.Domain.Entities.Response;
using WebAplication.Domain.Entities.User;
using WebAplication.Domain.Enums;
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

        internal URegisterResp RegisterUpService(URegisterData data)
        {
            UserTable existingUser;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                using (var db = new UserContext())
                {
                    existingUser = db.Users.FirstOrDefault(u => u.Email == data.Email);
                }

                if (existingUser != null)
                {
                    return new URegisterResp { IsSuccess = false, Status = "User With Email Already Exists" };
                }

                //var pass = LoginHelper.HashGen(data.Password);
                var newUser = new UserTable
                {
                    Email = data.Email,
                    Username = data.Username,
                    Password = data.Password,
                    LastIp = data.LoginIP,
                    LastLogin = data.LoginDataTime,
                    Level = (URole)0,
                };

                using (var todo = new UserContext())
                {
                    todo.Users.Add(newUser);
                    todo.SaveChanges();
                }
                return new URegisterResp { IsSuccess = true };
            }
            else
                return new URegisterResp { IsSuccess = false };
        }
    }

}
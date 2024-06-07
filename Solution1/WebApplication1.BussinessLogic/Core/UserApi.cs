using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BussinessLogic.DBModel;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Helper;

namespace WebApplication1.BussinessLogic.Core
{
    public class UserApi
    {
        internal BoolResp UserLoginAction(ULoginData data)
        {
            var pass = LoginHelper.HashGen(data.Password);
            using (var db = new TableContext())
            {
                UDbTable result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == pass);
                if (result == null)
                {
                    return new BoolResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }
                result.LastIp = data.LoginIP;
                result.LastLogin = data.LoginDateTime;
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
            }
            return new BoolResp { Status = true };
        }

        internal BoolResp UserRegisterAction(URegisterData data)
        {
            using (var db = new TableContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == data.Username);
                if (user != null)
                {
                    return new BoolResp { Status = false, StatusMsg = "User already registered." };
                }
                var pass = LoginHelper.HashGen(data.Password);
                UDbTable newUser = new UDbTable
                {
                    Username = data.Username,
                    Id = 1,
                    Password = pass,
                    LastIp = data.LoginIP,
                    LastLogin = data.LoginDateTime,
                    Level = 0,
                    Image = "default.png",

                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            return new BoolResp { Status = true };
        }
    }
}

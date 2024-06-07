using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Web;
using WebApplication1.BussinessLogic.DBModel;
using WebApplication1.Helper;
using WebApplication1.Domain.Entities.User;

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

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new TableContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new TableContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new TableContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new TableContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var userminimal = Mapper.Map<UserMinimal>(curentUser);
            return userminimal;
        }
    }
}

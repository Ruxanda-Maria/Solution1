using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BussinessLogic.DBModel;
using WebApplication1.Domain.Entities.Admin;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Helper;

namespace WebApplication1.BussinessLogic.Core
{
    public class AdminApi
    {
        internal BoolResp AddUserAction(AddUserData data)
        {
            using (var db = new TableContext())
            {
                UDbTable existingUser = db.Users.FirstOrDefault(u => u.Username == data.Username);
                if (existingUser != null)
                {
                    return new BoolResp { Status = false, StatusMsg = "User already registered." };
                }

                var newUser = new UDbTable
                {
                    Username = data.Username,
                    Password = LoginHelper.HashGen(data.Password),
                    Level = data.Level,
                    LastLogin = DateTime.Now,
                    LastIp = "None",
                    Image = "default.png",
                };
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            return new BoolResp { Status = true };
        }
    }
}

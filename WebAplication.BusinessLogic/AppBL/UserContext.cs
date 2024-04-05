using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domain.Entities.User;

namespace WebAplication.BusinessLogic.AppBL
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("name=WebApplication")
        {
        }

        public virtual DbSet<UserTable> Users { get; set; }
    }
}

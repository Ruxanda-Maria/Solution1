using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Product;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BussinessLogic.DBModel
{
    public class TableContext : DbContext
    {
        public TableContext() : base("name=WebApplication1")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<UDbTable> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}

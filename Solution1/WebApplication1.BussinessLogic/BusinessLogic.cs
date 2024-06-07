using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BussinessLogic.DBModel;
using WebApplication1.BussinessLogic.Interface;

namespace WebApplication1.BussinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public IAdmin GetAdminBL()
        {
            return new AdminBL();
        }
    }
}

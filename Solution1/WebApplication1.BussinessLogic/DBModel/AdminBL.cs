using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BussinessLogic.Core;
using WebApplication1.BussinessLogic.Interface;
using WebApplication1.Domain.Entities.Admin;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BussinessLogic.DBModel
{
    public class AdminBL : AdminApi, IAdmin
    {
        public BoolResp AddUser(AddUserData data)
        {
            return AddUserAction(data);
        }

        public void DeleteUser(int id)
        {
            DeleteUserAction(id);
        }

        public BoolResp AddProduct(AddProductData data)
        {
            return AddProductAction(data);
        }

        public BoolResp EditProduct(EditProductData data)
        {
            return EditProductAction(data);
        }

        public void DeleteProduct(int id)
        {
            DeleteProductAction(id);
        }
    }
}

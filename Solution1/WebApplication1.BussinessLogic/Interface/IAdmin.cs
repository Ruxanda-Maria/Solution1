using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Admin;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BussinessLogic.Interface
{
    public interface IAdmin
    {
        BoolResp AddUser(AddUserData data);
        void DeleteUser(int id);
        BoolResp AddProduct(AddProductData data);
        BoolResp EditProduct(EditProductData data);
        void DeleteProduct(int id);
    }
}

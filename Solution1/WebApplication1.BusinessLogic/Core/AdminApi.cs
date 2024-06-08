using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.Domain.Entities.Admin;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Helpers;

namespace WebApplication1.BusinessLogic.Core
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

          internal void DeleteUserAction(int id)
          {
               using (var db = new TableContext())
               {
                    UDbTable user = db.Users.FirstOrDefault(u => u.Id == id);
                    db.Users.Remove(user);
                    db.SaveChanges();
               }
          }

          internal BoolResp AddProductAction(AddProductData data)
          {
               using (var db = new TableContext())
               {
                    Product existingProduct = db.Products.FirstOrDefault(u => u.Name == data.Name);
                    if (existingProduct != null)
                    {
                         return new BoolResp { Status = false, StatusMsg = "Product already registered." };
                    }

                    var newProduct = new Product
                    {
                         Name = data.Name,
                         Image = data.Name + ".png",
                         Type = data.Type,
                         Price = data.Price,
                         AddedTime = data.AddedTime,
                         Bought = 0,
                         Category = data.Category,
                         XS = data.XS,
                         S = data.S,
                         M = data.M,
                         L = data.L,
                         XL = data.XL,
                         Description = data.Description
                    };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
               }
               return new BoolResp { Status = true };
          }

          internal void DeleteProductAction(int id)
          {
               using (var db = new TableContext())
               {
                    Product product = db.Products.FirstOrDefault(u => u.Id == id);
                    db.Products.Remove(product);
                    db.SaveChanges();
               }
          }

          internal BoolResp EditProductAction(EditProductData data)
          {
               using (var db = new TableContext())
               {
                    Product existingProduct = db.Products.FirstOrDefault(u => u.Name == data.Name);
                    existingProduct.Name = data.Name;
                    existingProduct.Type = data.Type;
                    existingProduct.Price = data.Price;
                    existingProduct.AddedTime = data.AddedTime;
                    existingProduct.Bought = data.Bought;
                    existingProduct.Category = data.Category;
                    existingProduct.XS = data.XS;
                    existingProduct.S = data.S;
                    existingProduct.M = data.M;
                    existingProduct.L = data.L;
                    existingProduct.XL = data.XL;
                    existingProduct.Description = data.Description;
                    db.SaveChanges();
               }
               return new BoolResp { Status = true };
          }
     }
}

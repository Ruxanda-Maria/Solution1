using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BusinessLogic.DBModel;
using WebApplication1.BusinessLogic.Interfaces;
using WebApplication1.BusinessLogic;
using WebApplication1.Domain.Entities.User;
using AutoMapper;
using WebApplication1.Domain.Entities.Admin;
using WebApplication1.Models;
using System.IO;
using System.Web.UI.WebControls;

namespace WebApplication1.Controllers
{
    public class AdminController : BaseController
    {
          private readonly IAdmin _admin;
          private readonly ISession _session;

          public AdminController()
          {
               var bl = new BussinesLogic();
               _admin = bl.GetAdminBL();
               _session = bl.GetSessionBL();
          }

          public void GetCurrentUserAndStatus()
          {
               SessionStatus();
               var apiCookie = System.Web.HttpContext.Current.Request.Cookies["X-KEY"];
               string userStatus = (string)System.Web.HttpContext.Current.Session["LoginStatus"];
               if (userStatus != "guest")
               {
                    var profile = _session.GetUserByCookie(apiCookie.Value);
                    ViewBag.user = profile;
               }
               ViewBag.userStatus = userStatus;
          }

          public ActionResult AddUser()
          {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    List<UDbTable> usersList = db.Users.OrderByDescending(u => u.Level).ToList();
                    ViewBag.usersList = usersList;
               }
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult AddUser(AddUser user)
          {
               if (ModelState.IsValid)
               {
                    var data = Mapper.Map<AddUserData>(user);

                    var addUser = _admin.AddUser(data);
                    if (addUser.Status)
                    {
                         return RedirectToAction("AddUser", "Admin");
                    }
                    else
                    {
                         ModelState.AddModelError("", addUser.StatusMsg);
                         return View();
                    }
               }
               return View();
          }

          public ActionResult DeleteUser(int id)
          {
               _admin.DeleteUser(id);
               return RedirectToAction("AddUser", "Admin");
          }

          public ActionResult AddProduct()
          {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    List<Product> productsList = db.Products.ToList();
                    List<string> TypeList = new List<string> { "Rochie Mireasa", "Rechie Domnisoara", "Incaltaminte", "Accesorii" };
                    List<string> boolList = new List<string> { "True", "False" };
                    List<string> categoryList = new List<string> { "Mirese", "Domnișoare de onoare", "Fetițe" };
                    ViewBag.categoryList = categoryList;
                    ViewBag.boolList = boolList;
                    ViewBag.TypeList = TypeList;
                    ViewBag.productsList = productsList;
               }
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult AddProduct(AddProduct product, HttpPostedFileBase imageFile)
          {
               if (ModelState.IsValid)
               {
                    if (imageFile != null && imageFile.ContentType == "image/png")
                    {
                         using (var db = new TableContext())
                         {
                              var path = Path.Combine(Server.MapPath($"~/Images/product/{product.Name}.png"));
                              imageFile.SaveAs(path);
                         }
                    }

                    var data = Mapper.Map<AddProductData>(product);
                    data.Image = "None";

                    var addProduct = _admin.AddProduct(data);
                    if (addProduct.Status)
                    {
                         return RedirectToAction("AddProduct", "Admin");
                    }
                    else
                    {
                         ModelState.AddModelError("", addProduct.StatusMsg);
                         return View();
                    }
               }
               return View();
          }

          public ActionResult DeleteProduct(int id)
          {
               using (var db = new TableContext())
               {
                    Product product = db.Products.FirstOrDefault(u => u.Id == id);
                    var path = Path.Combine(Server.MapPath($"~/Images/product/{product.Image}"));
                    System.IO.File.Delete(path);
               }
               _admin.DeleteProduct(id);
               return RedirectToAction("AddProduct", "Admin");
          }

          public ActionResult EditProduct(int id)
          {
               GetCurrentUserAndStatus();
               using (var db = new TableContext())
               {
                    var product = db.Products.FirstOrDefault(u => u.Id == id);
                    var data = Mapper.Map<EditProduct>(product);
                    List<string> TypeList = new List<string> { "Rochie Mireasa", "Rechie Domnisoara", "Incaltaminte", "Accesorii" };
                    List<string> boolList = new List<string> { "True", "False" };
                    List<string> categoryList = new List<string> { "Mirese", "Domnișoare de onoare", "Fetițe" };
                    ViewBag.categoryList = categoryList;
                    ViewBag.boolList = boolList;
                    ViewBag.TypeList = TypeList;
                    ViewBag.productToEdit = data;
                    return View(data);
               }
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult EditProduct(EditProduct product, HttpPostedFileBase imageFile)
          {
               if (ModelState.IsValid)
               {
                    if (imageFile != null && imageFile.ContentType == "image/png")
                    {
                         using (var db = new TableContext())
                         {
                              Product existingProduct = db.Products.FirstOrDefault(u => u.Name == product.Name);
                              var path = Path.Combine(Server.MapPath($"~/Images/product/{existingProduct.Name}.png"));
                              existingProduct.Image = existingProduct.Name + ".png";
                              db.SaveChanges();
                              System.IO.File.Delete(path);
                              imageFile.SaveAs(path);
                         }
                    }

                    var data = Mapper.Map<EditProductData>(product);

                    var editProduct = _admin.EditProduct(data);
                    if (editProduct.Status)
                    {
                         return RedirectToAction("AddProduct", "Admin");
                    }
                    else
                    {
                         ModelState.AddModelError("", editProduct.StatusMsg);
                         return View();
                    }
               }
               return View();
          }
     }
}
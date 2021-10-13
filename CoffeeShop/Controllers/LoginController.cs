using CoffeeShop.Models;
using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        private DataContext db = new DataContext();

        private void MigrateShoppingCart(string Email)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.MigrateCart(Email);
            Session[ShoppingCart.CartSessionKey] = Email;
        }
        // GET: Login
        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]


        public ActionResult CustomerLogin(string email, string password, CustomerRegister model)
        {
            if (ModelState.IsValid)

            {
                var data = db.CustomerRegisters.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    MigrateShoppingCart(model.Email);
                    return RedirectToAction("Home", "Customer");
                }

                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("CustomerLogin");
                }


            }
            return View();

        }








        public ActionResult CustomerLogOut()
        {
            Session.Clear();
            ModelState.Clear();
            return RedirectToAction("CustomerLogin");
        }




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]


        public ActionResult EmployeeLogin(string email, string password, EmployeeRegister model)
        {
            if (ModelState.IsValid)

            {
                var data = db.EmployeeRegisters.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    MigrateShoppingCart(model.Email);
                    return RedirectToAction("Home", "Employee");
                }

                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("EmployeeLogin");
                }


            }
            return View();

        }




        public ActionResult EmployeeLogOut()
        {
            Session.Clear();
            return RedirectToAction("EmployeeLogin");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]


        public ActionResult AdminLogin(string email, string password, EmployeeRegister model)
        {
            if (ModelState.IsValid)

            {
                var data = db.AdminRegisters.Where(a => a.Email.Equals(email) && a.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    MigrateShoppingCart(model.Email);
                    return RedirectToAction("Index", "AdminRegisters");
                }

                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("AdminLogin");
                }


            }
            return View();

        }




        public ActionResult AdminLogOut()
        {
            Session.Clear();
            return RedirectToAction("AdminLogin");
        }





       










    }
}



































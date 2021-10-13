using CoffeeShop.Models;
using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Controllers
{
    public class CheckoutController : Controller
    {
        DataContext db = new DataContext();
        //const string PromoCode = "50";

        public ActionResult AddressAndPayment()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                //if (string.Equals(values["PromoCode"], PromoCode,
                //    StringComparison.OrdinalIgnoreCase) == false)
                //{
                //    return View(order);
                //}
                //else
                {
                    order.Username = Convert.ToString(Session["UserName"]);
                    order.OrderDate = DateTime.Now;
                    order.Email = Convert.ToString(Session["Email"]);
                    order.Ordername = Convert.ToString(Session["UserName"]);
                    order.Total = order.Total;


                    db.Orders.Add(order);
                    db.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {

                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {

            bool isValid = db.Orders.Any(
                o => o.OrderId == id); //&&
                //o.Username == User.Identity.ToString());

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        











    }
}
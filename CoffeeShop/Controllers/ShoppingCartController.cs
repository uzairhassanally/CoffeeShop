using CoffeeShop.Models;
using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ShoppingCartController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {

            var addedItem = db.Items
                .Single(item => item.ItemId == id);


            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);


            string itemName = db.Carts
                .Single(item => item.RecordId == id).Item.Title;


            int itemCount = cart.RemoveFromCart(id);


            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(itemName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


        /////////////////Confirm Order////////////////////////////////////////////////

        public ActionResult Confirm()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

       

    }
}
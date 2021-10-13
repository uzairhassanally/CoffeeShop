using CoffeeShop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class FrontPageController : Controller
    {
        DataContext db = new DataContext();
        private List<Item> GetTopSellingItems(int count)
        {
            return db.Items.OrderByDescending(i => i.OrderDetails.Count())
                .Take(count)
                .ToList();
        }



        public ActionResult Index()
        {
            var items = GetTopSellingItems(10);
            return View(items);
        }



    }
}
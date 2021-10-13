﻿using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class StoreController : Controller
    {
        DataContext storeDB = new DataContext();
        // GET: Store
        public ActionResult Index()
        {
            var categories = storeDB.Categories.ToList();

            return View(categories);
        }
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);

        }
        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Items")
                .Single(c => c.Name == category);
            return View(categoryModel);
        }
        public ActionResult Details(int id)
        {
            var Item = storeDB.Items.Find(id);
            return View(Item);
        }
    }
}
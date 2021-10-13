using CoffeeShop.Models;
using CoffeeShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        public DataContext db = new DataContext();

        private void MigrateShoppingCart(string Email)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.MigrateCart(Email);
            Session[ShoppingCart.CartSessionKey] = Email;
        }

        /// /////////////////////////////Customer Home Page///////////////////////////////////////////////////


        public ActionResult Home()
        {

            return View();
        }




        /// //////////////////////////////////////////////////////////////////////////////










        ////////////////////////////Customer Registers///////////////////////////////////////////////////////////////////////////
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerRegistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "To,Email,Month,Year,Date,FirstName,LastName,UserName,Password")] CustomerRegister customerRegistration)
        {
            if (ModelState.IsValid)
            {

                db.CustomerRegisters.Add(customerRegistration);
                db.SaveChanges();
                return RedirectToAction("CustomerLogin", "Login");
            }

            return View(customerRegistration);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////



        ////////////////////////////////////////////////////////////////////////
        ////////////////Customer Details/////////////////////////////////////////////
        ///////////////////////////////////
        public ActionResult My_Details()
        {
            using (DataContext db = new DataContext())
            {

                string UserName = Convert.ToString(Session["UserName"]);
                if (UserName == null)
                {
                    return RedirectToAction("CustomerLogin", "Login");
                }

                return View(db.CustomerRegisters.Find(UserName));
            }

        }

        ////////////////////////////////////////////////////////////////////////
        ////////////////End Customer Details/////////////////////////////////////////////
        ///////////////////////////////////










        ////////////////////////////////////////////////////////////////////////
        ////////////////Employees Change Details/////////////////////////////////////////////
        ///////////////////////////////////


        public ActionResult Edit_My_Details()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Edit_My_Details(CustomerUpdateDetailsVM Details)
        {
            using (DataContext db = new DataContext())
            {
                string UserName = Convert.ToString(Session["UserName"]);
                CustomerRegister e = db.CustomerRegisters.Find(UserName);

                if (e.Password == Details.CurrentPassword || e.FirstName == Details.CurrentFirstName || e.LastName == Details.CurrentLastName || e.Email == Details.CurrentEmail || e.Year == Details.CurrentYear || e.Month == Details.CurrentMonth ||e.Date ==Details.CurrentDate)
                {
                    e.Password = Details.NewPassWord;
                    e.FirstName = Details.UpdateFirstName;
                    e.LastName = Details.UpdateLastName;
                    e.Email = Details.UpdateEmail;
                    e.Date = Details.UpdateDate;
                    e.Month = Details.UpdateMonth;
                    e.Year = Details.UpdateYear;

                    db.Entry(e).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Your Details Has been Updated";
                }
                else
                {
                    ViewBag.Message = "Your olds details is incorrect therefore new details Has Not been Updated";

                }
                return View("Edit_My_Details");
            }

        }


        ////////////////////////////////////////////////////////////////////////
        ////////////////End Customer Change Details/////////////////////////////////////////////
        ///////////////////////////////////




        /////////////////////////Media//////////////////////////////////////////////////
        ///
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArticleId = id.Value;

            var comments = db.ArticlesComments.Where(d => d.ArticleId.Equals(id.Value)).ToList();
            ViewBag.Comments = comments;

            var ratings = db.ArticlesComments.Where(d => d.ArticleId.Equals(id.Value)).ToList();
            if (ratings.Count() > 0)
            {
                var ratingSum = ratings.Sum(d => d.Rating.Value);
                ViewBag.RatingSum = ratingSum;
                var ratingCount = ratings.Count();
                ViewBag.RatingCount = ratingCount;
            }
            else
            {
                ViewBag.RatingSum = 0;
                ViewBag.RatingCount = 0;
            }

            return View(article);
        }

        // GET: Articles/Create
        public ActionResult CreateNew()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "AutoId,Like,Title,Description,Active")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.Like = 0;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }






            return View(article);
        }

        public ActionResult Like(int id)
        {
            Article update = db.Articles.ToList().Find(u => u.AutoId == id);
            update.Like += 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoId,Like,Title,Description,Active")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

















        ///////////////////////End Media////////////////////////////////////////////////








        ///////////////////////////////Store????////////////////////////////////////////////////////////////


        public ActionResult StoreIndex()
        {
            var categories = db.Categories.ToList();

            return View(categories);
        }
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.Categories.ToList();
            return PartialView(categories);

        }
        public ActionResult Browse(string category)
        {
            var categoryModel = db.Categories.Include("Items")
                .Single(c => c.Name == category);
            return View(categoryModel);
        }
        public ActionResult StoreDetails(int id)
        {
            var Item = db.Items.Find(id);
            return View(Item);




        }

        ////////////////////////////////////end store?????????????/////////////////////////////



        //public ActionResult ShoppingCartIndex()
        //{
        //    var cart = ShoppingCart.GetCart(this.HttpContext);


        //    var viewModel = new ShoppingCartViewModel
        //    {
        //        CartItems = cart.GetCartItems(),
        //        CartTotal = cart.GetTotal()
        //    };

        //    return View(viewModel);
        //}

        //public ActionResult AddToCart(int id)
        //{

        //    var addedItem = db.Items
        //        .Single(item => item.ItemId == id);


        //    var cart = ShoppingCart.GetCart(this.HttpContext);

        //    cart.AddToCart(addedItem);


        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult RemoveFromCart(int id)
        //{

        //    var cart = ShoppingCart.GetCart(this.HttpContext);


        //    string itemName = db.Carts
        //        .Single(item => item.RecordId == id).Item.Title;


        //    int itemCount = cart.RemoveFromCart(id);


        //    var results = new ShoppingCartRemoveViewModel
        //    {
        //        Message = Server.HtmlEncode(itemName) +
        //            " has been removed from your shopping cart.",
        //        CartTotal = cart.GetTotal(),
        //        CartCount = cart.GetCount(),
        //        ItemCount = itemCount,
        //        DeleteId = id
        //    };
        //    return Json(results);
        //}

        //[ChildActionOnly]
        //public ActionResult CartSummary()
        //{
        //    var cart = ShoppingCart.GetCart(this.HttpContext);

        //    ViewData["CartCount"] = cart.GetCount();
        //    return View("CartSummary");
        //}


        //Customer Checkout is  checkout controller
        ///////////////////////////////////////////////////////////////////////////////////////

        /// //////////////////////////Customer Order////////////////////////////////////

        public ActionResult CustomersOrder()
        {
            
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5


        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }






        public ActionResult CustomerOrderDetail(string searchBy, string search)
        {
          
             if (searchBy == "Ordername")
            {
                return View(db.OrderDetails.Where(x => x.Order.Ordername == search || search == null).ToList());
            }
            else
            {
                return View(db.OrderDetails.ToList());
            }

            
        }


//////////////////////////Customer Order/////////////////////////////////////////////////////////////////


        public ActionResult OrderStatus()
        {
            return View(db.Updates.ToList());
        }
        
    }





}


































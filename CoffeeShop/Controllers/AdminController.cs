using CoffeeShop.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CoffeeShop.Controllers
{

    public class AdminController : Controller
    {
        // Media//////////////////////////////////////////////
        private DataContext db = new DataContext();

        // GET: Articles
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutoId,Like,Title,Description,Active")] Article article)
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


        ////////////////////end media////////////////////////////////////



        //////////////////Display Customers Birthday////////////////////////////////

        public ActionResult Birthday()
        {
            return View(db.CustomerRegisters.OrderByDescending(i =>i.Month).ToList());
        }

        // GET: CustomerRegisters/Details/5
        public ActionResult Wish(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerRegister customerRegister = db.CustomerRegisters.Find(id);
            if (customerRegister == null)
            {
                return HttpNotFound();
            }
            return View(customerRegister);
        }
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(CustomerRegister gmail)
        {
            gmail.SendMail();
            return RedirectToAction("Birthday", "Admin");
        }



        ///////////////////Display Customers Birthday////////////////////////////////////////////














    }
}












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
    public class EmployeeController : Controller
    {

        public DataContext db = new DataContext();

        ///////////////////////////////////////////////////////////////////////
        ////////////////Employees Home Page/////////////////////////////////////////////
        ///////////////////////////////////



        // GET: Employee
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult NewHome()
        {
            return View();
        }

        ///////////////////////////////////////////////////////////////////////
        ////////////////Employees Home Page/////////////////////////////////////////////
        ///////////////////////////////////












        ////////////////////////////////////////////////////////////////////////
        ////////////////Employees Details/////////////////////////////////////////////
        ///////////////////////////////////
        public ActionResult My_Details()
        {
            using (DataContext db = new DataContext())
            {

                string UserName = Convert.ToString(Session["UserName"]);
                if (UserName == null)
                {
                    return RedirectToAction("EmployeeLogin", "Login");
                }

                return View(db.EmployeeRegisters.Find(UserName));
            }

        }

        ////////////////////////////////////////////////////////////////////////
        ////////////////End Employees Details/////////////////////////////////////////////
        ///////////////////////////////////










        ////////////////////////////////////////////////////////////////////////
        ////////////////Employees Change Details/////////////////////////////////////////////
        ///////////////////////////////////


        public ActionResult Edit_My_Details()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Edit_My_Details(EmployeeUpdateDetailsVM Details)
        {
            using (DataContext db = new DataContext())
            {
                string UserName = Convert.ToString(Session["UserName"]);
                EmployeeRegister e = db.EmployeeRegisters.Find(UserName);

                if (e.Password == Details.CurrentPassword || e.FirstName == Details.CurrentFirstName || e.LastName == Details.CurrentLastName || e.Email == Details.CurrentEmail /*|| e.UserName == Details.CurrentUserName*/)
                {
                    e.Password = Details.NewPassword;
                    e.FirstName = Details.UpdateFirstName;
                    e.LastName = Details.UpdateLastName;
                    e.Email = Details.UpdateEmail;
                    //e.UserName = Details.UpdateUserName;

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
        ////////////////End Employees Change Details/////////////////////////////////////////////
        ///////////////////////////////////



        //////////////////////////Employee See detailed Orders (OrderDetails Controller)//////////////////////////////

        public ActionResult Index(string searchBy, string search)
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


        // GET: OrderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Title");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status,OrderDetailId,OrderId,ItemId,Quantity,UnitPrice")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Title", orderDetail.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username", orderDetail.OrderId);
            return View(orderDetail);
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Title", orderDetail.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username", orderDetail.OrderId);
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Status,OrderDetailId,OrderId,ItemId,Quantity,UnitPrice")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Title", orderDetail.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Username", orderDetail.OrderId);
            return View(orderDetail);
        }






        ///////////////////Ends detailed orders.(OrderDetails Controller)////////////////////////////////////



        ///////////////////  orders.(Order Controller)////////////////////////////////////



        public ActionResult Orders()
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


        public ActionResult EditOrders(int? id)
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

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOrders([Bind(Include = "Status,OrderDate,Email,Username,OrderId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }







        ///////////////////Ends  orders.(Order Controller)////////////////////////////////////
















        /////// Media//////////////////////////////////////////////


        // GET: Articles
        public ActionResult MediaIndex()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult MediaDetails(int? id)
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
        public ActionResult MediaCreate()
        {
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MediaCreate([Bind(Include = "AutoId,Like,Title,Description,Active")] Article article)
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
        public ActionResult MediaEdit(int? id)
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
        public ActionResult MediaEdit([Bind(Include = "AutoId,Like,Title,Description,Active")] Article article)
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
        public ActionResult MediaDelete(int? id)
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
        public ActionResult MediaDeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        ////////////////////end media////////////////////////////////////
        ///




        //////////////////////Calender/////////////////////////

        public ActionResult CalenderIndex()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (DataContext dc = new DataContext())
            {
                var events = dc.Schedulers.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }




        ///////////////////////End Calender/////////////////////////////







        //////////////////////////Task/////////////////////////////////////////////////////////////////////////////////

        public ActionResult WorkFLowIndex()
        {
            var workFlow = db.WorkFlow.Include(w => w.EmployeeRegister).Include(w => w.TaskDescription);
            return View(workFlow.ToList());
        }

        // GET: WorkFlows/Details/5
        public ActionResult WorkFlowDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkFlow workFlow = db.WorkFlow.Find(id);
            if (workFlow == null)
            {
                return HttpNotFound();
            }
            return View(workFlow);
        }











        ///////////////////////////////End Task/////////////////////////////////////////////////
        // GET: Updates/Create
        public ActionResult update()
        {
            return View();
        }

        // POST: Updates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult update([Bind(Include = "ID,Status,OrderID")] Updates updates)
        {
            if (ModelState.IsValid)
            {
                db.Updates.Add(updates);
                db.SaveChanges();
                return RedirectToAction("Orders", "Employee");
            }

            return View(updates);
        }




        /////update order id
        ///

        //public ActionResult OrderId(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        ///////////////////////////////////Sending Status Email/////////////////////////////////////////////////
        public ActionResult OrderAccepted()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderAccepted(Order gmail)
        {
            gmail.OrderAccepted();
            return RedirectToAction("Orders", "Employee");
        }


        public ActionResult OrderReady()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OrderReady(Order gmail)
        {
            gmail.OrderReady();
            return RedirectToAction("Orders", "Employee");
        }


        public ActionResult PickupConfirmed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PickupConfirmed(Order gmail)
        {
            gmail.PickupConfirmed();
            return RedirectToAction("Orders", "Employee");
        }


        ////////////////////////////////////////////End Status Email//////////////////////////////////////////////////////////





        public ActionResult WorkFlowEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkFlow workFlow = db.WorkFlow.Find(id);
            if (workFlow == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserName = new SelectList(db.EmployeeRegisters, "UserName", "FirstName", workFlow.UserName);
            ViewBag.NameId = new SelectList(db.TaskDescriptions, "NameId", "TaskName", workFlow.NameId);
            return View(workFlow);
        }

        // POST: WorkFlows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkFlowEdit([Bind(Include = "WorkFlowID,NameId,DueDate,Status,UserName")] WorkFlow workFlow, string searchBy)
        {
            if (ModelState.IsValid)
            {
                if (searchBy == "No")
                {
                    workFlow.Status = "No";
                }
                else
                {
                    workFlow.Status = "Yes";
                }

                db.Entry(workFlow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.EmployeeRegisters, "UserName", "FirstName", workFlow.UserName);
            ViewBag.NameId = new SelectList(db.TaskDescriptions, "NameId", "TaskName", workFlow.NameId);
            return View(workFlow);
        }

    }
}





















using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class CustomerRegistersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CustomerRegisters
        public ActionResult Index()
        {
            return View(db.CustomerRegisters.ToList());
        }

        // GET: CustomerRegisters/Details/5
        public ActionResult Details(string id)
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

        // GET: CustomerRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "To,UserName,FirstName,Date,Month,Year,LastName,Email,Password")] CustomerRegister customerRegister)
        {
            if (ModelState.IsValid)
            {
                db.CustomerRegisters.Add(customerRegister);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("CustomerLogin", "Login");
            }

            return View(customerRegister);
        }

        // GET: CustomerRegisters/Edit/5
        public ActionResult Edit(string id)
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

        // POST: CustomerRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "To,UserName,FirstName,Date,Month,Year,LastName,Email,Password")] CustomerRegister customerRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerRegister);
        }

        // GET: CustomerRegisters/Delete/5
        public ActionResult Delete(string id)
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

        // POST: CustomerRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CustomerRegister customerRegister = db.CustomerRegisters.Find(id);
            db.CustomerRegisters.Remove(customerRegister);
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
    }
}

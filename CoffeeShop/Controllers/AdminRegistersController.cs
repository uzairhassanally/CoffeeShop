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
    public class AdminRegistersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AdminRegisters
        public ActionResult Index()
        {
            return View(db.AdminRegisters.ToList());
        }

        // GET: AdminRegisters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRegister adminRegister = db.AdminRegisters.Find(id);
            if (adminRegister == null)
            {
                return HttpNotFound();
            }
            return View(adminRegister);
        }

        // GET: AdminRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,FirstName,LastName,UserName,Password")] AdminRegister adminRegister)
        {
            if (ModelState.IsValid)
            {
                db.AdminRegisters.Add(adminRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminRegister);
        }

        // GET: AdminRegisters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRegister adminRegister = db.AdminRegisters.Find(id);
            if (adminRegister == null)
            {
                return HttpNotFound();
            }
            return View(adminRegister);
        }

        // POST: AdminRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,FirstName,LastName,UserName,Password")] AdminRegister adminRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminRegister);
        }

        // GET: AdminRegisters/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminRegister adminRegister = db.AdminRegisters.Find(id);
            if (adminRegister == null)
            {
                return HttpNotFound();
            }
            return View(adminRegister);
        }

        // POST: AdminRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AdminRegister adminRegister = db.AdminRegisters.Find(id);
            db.AdminRegisters.Remove(adminRegister);
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

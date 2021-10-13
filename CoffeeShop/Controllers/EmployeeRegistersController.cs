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
    public class EmployeeRegistersController : Controller
    {
        private DataContext db = new DataContext();
      
        // GET: EmployeeRegisters
        public ActionResult Index(EmployeeRegister employee )
        {

            return View(db.EmployeeRegisters.ToList());
        }

        public ActionResult PayFast(EmployeeRegister employee)
        {

            return View(db.EmployeeRegisters.ToList());
        }

        // GET: EmployeeRegisters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRegisters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,FirstName,LastName,Role,Amount,EmployeeId,UserName,Password")] EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
               

                db.EmployeeRegisters.Add(employeeRegister);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // POST: EmployeeRegisters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,FirstName,LastName,Role,Amount,EmployeeId,UserName,Password")] EmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeRegister).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeRegister);
        }

        // GET: EmployeeRegisters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            if (employeeRegister == null)
            {
                return HttpNotFound();
            }
            return View(employeeRegister);
        }

        // POST: EmployeeRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRegister employeeRegister = db.EmployeeRegisters.Find(id);
            db.EmployeeRegisters.Remove(employeeRegister);
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

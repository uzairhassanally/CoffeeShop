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
    public class TaskDescriptionsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: TaskDescriptions
        public ActionResult Index()
        {
            return View(db.TaskDescriptions.ToList());
        }

        // GET: TaskDescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDescription taskDescription = db.TaskDescriptions.Find(id);
            if (taskDescription == null)
            {
                return HttpNotFound();
            }
            return View(taskDescription);
        }

        // GET: TaskDescriptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskDescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NameId,TaskName")] TaskDescription taskDescription)
        {
            if (ModelState.IsValid)
            {
                db.TaskDescriptions.Add(taskDescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskDescription);
        }

        // GET: TaskDescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDescription taskDescription = db.TaskDescriptions.Find(id);
            if (taskDescription == null)
            {
                return HttpNotFound();
            }
            return View(taskDescription);
        }

        // POST: TaskDescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NameId,TaskName")] TaskDescription taskDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskDescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskDescription);
        }

        // GET: TaskDescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskDescription taskDescription = db.TaskDescriptions.Find(id);
            if (taskDescription == null)
            {
                return HttpNotFound();
            }
            return View(taskDescription);
        }

        // POST: TaskDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskDescription taskDescription = db.TaskDescriptions.Find(id);
            db.TaskDescriptions.Remove(taskDescription);
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

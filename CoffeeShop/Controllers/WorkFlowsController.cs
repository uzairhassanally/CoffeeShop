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
    public class WorkFlowsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: WorkFlows
        public ActionResult Index()
        {
            var workFlow = db.WorkFlow.Include(w => w.EmployeeRegister).Include(w => w.TaskDescription);
            return View(workFlow.ToList());
        }

        // GET: WorkFlows/Details/5
        public ActionResult Details(int? id)
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

        // GET: WorkFlows/Create
        public ActionResult Create()
        {
            ViewBag.UserName = new SelectList(db.EmployeeRegisters, "UserName", "FirstName");
            ViewBag.NameId = new SelectList(db.TaskDescriptions, "NameId", "TaskName");
            return View();
        }

        // POST: WorkFlows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkFlowID,NameId,DueDate,Status,UserName")] WorkFlow workFlow, string searchBy)
        {

            


            if (ModelState.IsValid)
            {
                if (searchBy == "Urgent")
                {
                    workFlow.DueDate = DateTime.Today.ToString();
                }
                else
                {
                    workFlow.DueDate = "3 Days";
                }

                db.WorkFlow.Add(workFlow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserName = new SelectList(db.EmployeeRegisters, "UserName", "FirstName", workFlow.UserName);
            ViewBag.NameId = new SelectList(db.TaskDescriptions, "NameId", "TaskName", workFlow.NameId);
            return View(workFlow);
        }

        // GET: WorkFlows/Edit/5
        public ActionResult Edit(int? id)
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
        public ActionResult Edit([Bind(Include = "WorkFlowID,NameId,DueDate,Status,UserName")] WorkFlow workFlow, string searchBy)
        {
            if (ModelState.IsValid)
            {
                if (searchBy == "Urgent")
                {
                    workFlow.DueDate = "Today";
                }
                else
                {
                    workFlow.DueDate = "3 Days";
                }

                db.Entry(workFlow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserName = new SelectList(db.EmployeeRegisters, "UserName", "FirstName", workFlow.UserName);
            ViewBag.NameId = new SelectList(db.TaskDescriptions, "NameId", "TaskName", workFlow.NameId);
            return View(workFlow);
        }

        // GET: WorkFlows/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: WorkFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkFlow workFlow = db.WorkFlow.Find(id);
            db.WorkFlow.Remove(workFlow);
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

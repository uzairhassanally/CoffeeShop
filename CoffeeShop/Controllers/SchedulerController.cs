using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class SchedulerController : Controller
    {
        
        // GET: Scheduler
        public ActionResult Index()
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




        [HttpPost]
        public JsonResult SaveEvent(Scheduler e)
        {
            var status = false;
            using ( DataContext dc = new DataContext())
            {
                if (e.EventId > 0)
                {
                    //Update the event
                    var v = dc.Schedulers.Where(a => a.EventId == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Schedulers.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }




        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (DataContext dc = new DataContext())
            {
                var v = dc.Schedulers.Where(a => a.EventId == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Schedulers.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }



    }
}
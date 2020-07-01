using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NGOProject.Models;

namespace NGOProject.Controllers
{
    public class eventsRegistrationController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();

        // GET: eventsRegistration
        public ActionResult Index()
        {
            return View(db.eventsTables.ToList());
        }

        // GET: eventsRegistration/Details/5
        public ActionResult Details(int? id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                eventsTable eventsTable = db.eventsTables.Find(id);
                if (eventsTable == null)
                {
                    return HttpNotFound();
                }

                return View(eventsTable);
        }

        // GET: eventsRegistration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventsRegistration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventDescription,eventCategory,eventStartDate,eventEndDate,eventStartTime,eventEndTime,registration,adultPrice,childPrice,eventID,image")] eventsTable eventsTable)
        {
            if (ModelState.IsValid)
            {
                db.eventsTables.Add(eventsTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsTable);
        }

        // GET: eventsRegistration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventsTable eventsTable = db.eventsTables.Find(id);
            if (eventsTable == null)
            {
                return HttpNotFound();
            }
            return View(eventsTable);
        }

        // POST: eventsRegistration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventDescription,eventCategory,eventStartDate,eventEndDate,eventStartTime,eventEndTime,registration,adultPrice,childPrice,eventID,image")] eventsTable eventsTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsTable);
        }

        // GET: eventsRegistration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventsTable eventsTable = db.eventsTables.Find(id);
            if (eventsTable == null)
            {
                return HttpNotFound();
            }
            return View(eventsTable);
        }

        // POST: eventsRegistration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventsTable eventsTable = db.eventsTables.Find(id);
            db.eventsTables.Remove(eventsTable);
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

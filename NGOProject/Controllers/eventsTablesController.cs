using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NGOProject.Models;

namespace NGOProject.Controllers
{
    public class eventsTablesController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();

        // GET: eventsTables
        public ActionResult Index()
        {
            return View(db.eventsTables.ToList());
        }

        // GET: eventsTables/Details/5
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

        // GET: eventsTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "eventDescription,eventCategory,eventStartDate,eventEndDate,eventStartTime,eventEndTime,registration,adultPrice,childPrice,eventID,image")] eventsTable eventsTable, HttpPostedFileBase file)
        {
            //string fileName = Path.GetFileNameWithoutExtension(eventsTable.imageFile.FileName);
            //string extension = Path.GetExtension(eventsTable.imageFile.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //eventsTable.image = "~/Content/Images/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
            //eventsTable.imageFile.SaveAs(fileName);
            if (ModelState.IsValid)
            {
                    string ImageName = System.IO.Path.GetFileName(file.FileName);
                    string physicalPath = Server.MapPath("~/Content/Images/" + ImageName);

                    // save image in folder
                    file.SaveAs(physicalPath);

                    //save new record in database
                    eventsTable.image = ImageName;
                    db.eventsTables.Add(eventsTable);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsTable);
        }

        // GET: eventsTables/Edit/5
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

        // POST: eventsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "eventDescription,eventCategory,eventStartDate,eventEndDate,eventStartTime,eventEndTime,registration,adultPrice,childPrice,eventID,image")] eventsTable eventsTable, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                eventsTable.image = ImageName;
                db.Entry(eventsTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsTable);
        }

        // GET: eventsTables/Delete/5
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

        // POST: eventsTables/Delete/5
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

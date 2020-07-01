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
    public class ticketsController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();

        // GET: tickets
        public ActionResult Index()
        {
            var tickets = db.tickets.Include(t => t.eventsTable).Include(t => t.user);
            return View(tickets.ToList());
        }

        // GET: tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: tickets/Create
        public ActionResult Create(int? id)
        {
            //ViewBag.eventID = new SelectList(db.eventsTables, "eventID", "eventDescription");
            //ViewBag.userID = new SelectList(db.users, "userID", "firstName");
            ViewBag.eventID = id.ToString();
            var eventTable = db.eventsTables.Find(id);
            ViewBag.adultPrice = eventTable.adultPrice;
            ViewBag.childPrice = eventTable.childPrice;
            return View();
        }

        // POST: tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "buyerPhone,buyerAddress,totalAdult,totalChildren,ticketID,eventID,totalPrice")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.userID = Convert.ToInt32(Session["userID"]);
                var eventTable = db.eventsTables.Find(id);
                var x = eventTable.adultPrice;
                var y = eventTable.childPrice;
                var x1 = ticket.totalChildren;
                var y1 = ticket.totalAdult;
                var total = (x * x1) + (y * y1);
                ticket.totalPrice = Convert.ToInt32(total);
                db.tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index", "Confirmation", new { ticketID=ticket.ticketID, eventID=ticket.eventID });
            }

            ViewBag.eventID = ticket.ticketID;
            //ViewBag.eventID = new SelectList(db.eventsTables, "eventID", "eventDescription", ticket.eventID);
            //ViewBag.userID = new SelectList(db.users, "userID", "firstName", ticket.userID);
            return View(ticket);
        }

        // GET: tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.eventID = new SelectList(db.eventsTables, "eventID", "eventDescription", ticket.eventID);
            ViewBag.userID = new SelectList(db.users, "userID", "firstName", ticket.userID);
            return View(ticket);
        }



        // POST: tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "buyerPhone,buyerAddress,totalAdult,totalChildren,ticketID,userID,eventID")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.eventID = new SelectList(db.eventsTables, "eventID", "eventDescription", ticket.eventID);
            ViewBag.userID = new SelectList(db.users, "userID", "firstName", ticket.userID);
            return View(ticket);
        }

        // GET: tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ticket ticket = db.tickets.Find(id);
            db.tickets.Remove(ticket);
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

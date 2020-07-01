using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGOProject.Models;

namespace NGOProject.Controllers
{
    public class ticketsBoughtController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();
        // GET: ticketsBought
        public ActionResult TicketsBought()
        {
            var data = db.tickets.SqlQuery("SELECT firstName, lastName, email, buyerPhone, buyerAddress,totalAdult, totalChildren, totalPrice, eventDescription, eventStartDate " +
                "FROM dbo.users as u INNER JOIN dbo.tickets as t " +
                "ON u.userID = t.userID " +
                "INNER JOIN dbo.eventsTable e " +
                "ON t.eventID = e.eventID");
            return View(data);
        }
    }
}
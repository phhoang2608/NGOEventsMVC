using NGOProject.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGOProject.Controllers
{
    public class ConfirmationController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();
        // GET: Confirmation
        public ActionResult Index(int? ticketID, int? eventID)
        {
            var tickets = db.tickets.Find(ticketID);
            var events = db.eventsTables.Find(eventID);

            dynamic MultiModel = new ExpandoObject();
            MultiModel.TICKETS = tickets;
            MultiModel.EVENTS = events;
            return View(MultiModel);
        }

        
    }
}
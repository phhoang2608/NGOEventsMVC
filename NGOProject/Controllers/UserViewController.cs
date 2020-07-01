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
    public class UserViewController : Controller
    {
        private NGOEventsEntities db = new NGOEventsEntities();
        // GET: UserView
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TicketBought(int? id)
        {
            return View();
        }
    }
}
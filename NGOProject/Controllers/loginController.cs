using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NGOProject.Models;

namespace NGOProject.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(user model)
        {
            using (var context = new NGOEventsEntities())
            {
                var userDetails = context.users.Where(x => x.email == model.email && x.password == model.password).FirstOrDefault();
                bool isValid = context.users.Any(x => x.email == model.email && x.password == model.password);
                if (!isValid || userDetails == null)
                {
                    ViewBag.Message = "Wrong Email and/or Password";
                    return View();
                }
                else
                {
                    Session["role"] = userDetails.role;
                    Session["email"] = userDetails.email;
                    Session["firstName"] = userDetails.firstName;
                    Session["lastName"] = userDetails.lastName;
                    Session["userID"] = userDetails.userID;
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    if (userDetails.role == "admin")
                    {
                        return RedirectToAction("Index", "AdminView");
                    }
                    return RedirectToAction("Index", "UserView");
                }
            }
            
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login"); 
        }
    }
}
using StudentInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentInformation.Controllers
{
    public class AccountController : Controller
    {
        private ClassInfoEntities db = new ClassInfoEntities();
        // GET: Account
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Models.User model)
        {
            using (var context = new ClassInfoEntities ())
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                bool Isvalid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password);
                if (Isvalid)
                {
                    return RedirectToAction("Create", "Studentinfo");
                }
                ModelState.AddModelError("", "Invalid UserName And Password");
                return View();
            }

        }
    }
}
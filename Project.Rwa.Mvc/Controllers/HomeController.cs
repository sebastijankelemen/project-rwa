using Project.Rwa.Mvc.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Rwa.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Djelatnik objUser)
        {
            if (ModelState.IsValid)
            {
                WorkHoursEntities db = new WorkHoursEntities();
                var obj = db.Djelatniks.Where(a => a.Email.Equals(objUser.Email)
                           && a.Zaporka.Equals(objUser.Zaporka)).FirstOrDefault();

                if (obj != null)
                {
                    Session["UserEmail"] = obj.Email;
                    return RedirectToAction("MainPage");
                }
            }

            ModelState.AddModelError("", Strings.FailedLoginMessage);

            return View(objUser);
        }

        public ActionResult MainPage()
        {
            if (Session["UserEmail"] != null)
            {

                WorkHoursEntities db = new WorkHoursEntities();
                return View(db.Projekts.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
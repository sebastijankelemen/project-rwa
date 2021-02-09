using Project.Rwa.Mvc.Models;
using Project.Rwa.Mvc.Resources;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Rwa.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorkHoursEntities db = new WorkHoursEntities();

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
                var obj = db.Djelatniks.Where(a => a.Email.Equals(objUser.Email)
                           && a.Zaporka.Equals(objUser.Zaporka)).FirstOrDefault();

                if (obj != null)
                {
                    Session["UserEmail"] = obj.Email;
                    return RedirectToAction("MainPage", obj);
                }
            }

            ModelState.AddModelError("", Strings.FailedLoginMessage);

            return View(objUser);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult MainPage(Djelatnik djelatnik)
        {
            if (Session["UserEmail"] != null)
            {
                var userProjects = db.ProjektDjelatniks
                    .Where(p => p.DjelatnikID == djelatnik.IDDjelatnik)
                    .AsEnumerable()
                    .Select(p => new ProjectViewModel(p));

                return View(userProjects);
            }

            
            return RedirectToAction("Login");
        }

        public ActionResult UserEdit()
        {
            string userEmail = Session["UserEmail"].ToString();

            var user = db.ProjektDjelatniks
                .Where(p => p.Djelatnik.Email.Equals(userEmail))
                .Select(p => p.Djelatnik)
                .FirstOrDefault();

            return View(user);
        }

        public ActionResult ProjectStart()
        {
            return null;
        }
    }
}
using System.Web.Mvc;
using WebApplication3.Libs;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginInfo input)
        {
            if (!ModelState.IsValid)
                return View(input);

            if (input.Username == "gatec" && input.Password == "12345")
            {
                Auth.LogIn(input.Username, "Marketing");

                return RedirectToAction("Index", "Home");
            }
            else if (input.Username == "simplefarm" && input.Password == "123")
            {
                Auth.LogIn(input.Username, "Admin");

                return RedirectToAction("Index", "Home");
            }

            return View(input);

        }

        public ActionResult Logout()
        {
            Auth.LogOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
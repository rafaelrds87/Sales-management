using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Libs;

namespace WebApplication1.Controllers
{

    [AllowAnonymous]

    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {

            if(!ModelState.isValid)
            return View(input);

        }
       

            [HttpPost]

            public ActionResult Index(LoginInfo input)
            {


                 if (!ModelState.IsValid)
                 return View(input);

            if (input.UserName == "gatec" && input.Password == "12345")
            {
                Auth.LoGin(input.Username, "Marketing");

                return RedirectToAction("Index", "Home");
            }

            return View(input);


            }


        public ActionResult Logout()
        {
            Auth.Logout();

            return RedirectToAction("Index", "Home");

        }
    }
}
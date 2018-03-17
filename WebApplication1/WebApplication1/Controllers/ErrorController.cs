using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.Mensagem = "Desculpe, mas um erro não tratado ocorreu =(";

            return View();
        }

        public ActionResult Error404()
        {
            ViewBag.Mensagem = "Desculpe, esta página não foi encontrada =/";
        
        
            return View();
        }
    }
}
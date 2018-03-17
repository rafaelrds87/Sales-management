using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>();
        
        static ProductController()
        {
            var random = new Random();
            for (int i = 1; i <= 25; i++)
            {
                Products.Add(new Product()
                {
                    Id = i,
                    Name = "Product " + i,
                    Price = random.Next(10, 1000),
                    Stock = random.Next(0, 20)
                });
            }
        }

        public ActionResult Index()
        {
            var model = Products;

            return View(model);
        }

        public ActionResult ProductsOff()
        {
            var model = Products.Where(x => x.Price < 100).ToList();

            return View("Index", model);
        }

        public ActionResult Edit(int id)
        {
            var model = Products.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Product input)
        {
            var model = Products.FirstOrDefault(x => x.Id == input.Id);

            model.Name = input.Name;
            model.Price = input.Price;
            model.Stock = input.Stock;

            return RedirectToAction("Index");
        }


        public ActionResult Detail(int id)
        {
            var model = Products.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return HttpNotFound();
            
            return View(model);
        }

        public ActionResult GetJsonProducts()
        {
            return Json(Products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetJsonProduct(int id)
        {
            var model = Products.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return HttpNotFound();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImage()
        {
            var path = "C:\\image.png";
            return File(path, "image/png");
        }

    }
}
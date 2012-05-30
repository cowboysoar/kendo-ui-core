﻿using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts(string filterText)
        {
            var northwind = new NorthwindDataContext();

            var products = northwind.Products.Select(product => new ProductDto
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
                UnitsInStock = product.UnitsInStock ?? 0,
                UnitsOnOrder = product.UnitsOnOrder ?? 0,
                Discontinued = product.Discontinued
            });

            if (!string.IsNullOrEmpty(filterText))
            {
                products = products.Where(p => p.ProductName.Contains(filterText));
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomers()
        {
            return Json(new NorthwindDataContext().Customers, JsonRequestBehavior.AllowGet);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Eshop.DataAccess.InMemory;
using Eshop.Core.Models;

namespace Eshop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        //ProductRepository is class who can used th cash for memory        
        ProductRepository context;

        public ProductManagerController()
        {
            context = new ProductRepository();
        }
        //Return all product from context to Index
        // GET: ProductManager
        public ActionResult Index()
        {
            //Product list
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        //Create new product
        public ActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }

        //Create new product
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        //Edit product
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        //Edit product
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(productToEdit);
                }
                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;
                productToEdit.Price = product.Price;

                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}
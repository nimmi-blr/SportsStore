﻿using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore2.WebUI.Controllers
{
   
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int ProductId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductId);
            
                return View(product);
            

        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if(image!=null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if(deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }

            return RedirectToAction("Index");
        }
    }
}
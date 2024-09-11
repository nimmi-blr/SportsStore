using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore2.Domain.Abstract;
using SportsStore2.Domain.Entities;
using SportsStore2.WebUI.Models;

namespace SportsStore2.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        // GET: Product

        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category,int page = 1)
        {
            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = repository.Products
               .Where(p => p.Category == null || p.Category == category)
               .OrderBy(p => p.ProductID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
                currentCategory = category,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count(),
                }
            
               
            };
            return View(viewModel);
        }

        public FileContentResult GetImage(int ProductId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == ProductId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
            
        }
    }
    
}
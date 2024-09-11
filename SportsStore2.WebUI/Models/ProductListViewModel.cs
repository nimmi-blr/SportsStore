using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore2.Domain.Entities;

namespace SportsStore2.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string currentCategory { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore2.Domain.Entities
{
    public class Cart
    {
        private List<cartLine> lineCollection  = new List<cartLine>();

        public IEnumerable<cartLine> lines
        {
            get { return lineCollection; }
        }
        public void AddItem(Product product,int quantity) 
        {
            cartLine line = lineCollection.Where(e => e.product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new cartLine { product = product, quantity = quantity });
            }
            else
            {
                line.quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.product.ProductID == product.ProductID);
        }
        public void ClearItem() 
        {

            lineCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.product.Price * e.quantity);
        }
    }

    public class cartLine
    {
        public Product product { get; set; }
        public int quantity{ get; set; }
    }
}
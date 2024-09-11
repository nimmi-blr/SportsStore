using SportsStore2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore2.Domain.Abstract
{
    public interface IOrderProcess
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}

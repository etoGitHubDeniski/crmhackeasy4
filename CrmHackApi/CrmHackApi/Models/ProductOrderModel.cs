using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public OrderModel Order { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class ProductOrderWorkerModel
    {
        public ProductOrderModel ProductOrder { get; set; }
        public string RecommendedWorker { get; set; }

    }
}
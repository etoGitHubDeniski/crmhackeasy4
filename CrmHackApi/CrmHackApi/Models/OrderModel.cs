using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public ClientModel Client { get; set; }
        public DateTime DateCreated { get; set; }
        public WorkerModel Worker { get; set; }
        public StatusModel Status { get; set; }
    }
}
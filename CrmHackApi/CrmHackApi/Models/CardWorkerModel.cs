using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class CardWorkerModel
    {
        public int Id { get; set; }
        public CardModel Card { get; set; }
        public WorkerModel Worker { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ScrumEventModel ScrumEvent { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
    }
}
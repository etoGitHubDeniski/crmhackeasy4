using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class CardTaskModel
    {
        public int Id { get; set; }
        public CardModel Card { get; set; }
        public string Description { get; set; }
    }
}
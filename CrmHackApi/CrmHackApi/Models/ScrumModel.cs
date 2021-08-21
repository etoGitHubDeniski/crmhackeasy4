using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class ScrumModel
    {
        public CardModel Card { get; set; }
        public CardTask CardTask { get; set; }
        public ScrumEvent ScrumEvent { get; set; }
    }
}
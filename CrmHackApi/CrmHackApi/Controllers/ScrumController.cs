using CrmHackApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CrmHackApi.Controllers
{
    public class ScrumController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public ScrumController()
        {
            _ent = new CrmHackEntities();
        }


    }
}
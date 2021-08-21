using CrmHackApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CrmHackApi.Controllers
{
    public class ScrumEventController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public ScrumEventController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Get()
        {
            var scrumEvent = await _ent.ScrumEvent.Select(x => new ScrumEventModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, scrumEvent);
        }

        public async Task<HttpResponseMessage> Post([FromBody] ScrumEventModel scrumEventModel)
        {
            var scrumEvent = new ScrumEvent()
            {
                Name = scrumEventModel.Name
            };

            _ent.ScrumEvent.Add(scrumEvent);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, scrumEvent.Id);
        }

    }
}
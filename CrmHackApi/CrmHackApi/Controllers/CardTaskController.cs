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
    public class CardTaskController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public CardTaskController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Get(int id) 
        {
            var cardTask = await _ent.CardTask.Where(x => x.CardId == id).Select(x => new CardTaskModel()
            {
                Id = x.Id,
                Description = x.TaskDescription,
                Card = new CardModel() 
                {
                    Id = x.Card.Id,
                    Title = x.Card.Title,
                    ScrumEvent = new ScrumEventModel() 
                    {
                        Id = x.Card.ScrumEvent.Id,
                        Name = x.Card.ScrumEvent.Name
                    },
                    DateEnd = (DateTime)x.Card.DateEnd,
                    DateStart = (DateTime)x.Card.DateStart
                }
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, cardTask);
        }

        public async Task<HttpResponseMessage> Get()
        {
            var cardTask = await _ent.CardTask.Select(x => new CardTaskModel()
            {
                Id = x.Id,
                Description = x.TaskDescription,
                Card = new CardModel()
                {
                    Id = x.Card.Id,
                    Title = x.Card.Title,
                    ScrumEvent = new ScrumEventModel()
                    {
                        Id = x.Card.ScrumEvent.Id,
                        Name = x.Card.ScrumEvent.Name
                    },
                    DateEnd = (DateTime)x.Card.DateEnd,
                    DateStart = (DateTime)x.Card.DateStart
                }
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, cardTask);
        }

        public async Task<HttpResponseMessage> Post([FromBody] CardTaskModel cardTaskModel)
        {
            var cardTask = new CardTask()
            {
                CardId = cardTaskModel.Card.Id,
                TaskDescription = cardTaskModel.Description
            };

            _ent.CardTask.Add(cardTask);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, cardTask.Id);

        }
    }
}

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
    public class CardController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public CardController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Get() 
        {
            var card = await _ent.Card.Select(x => new CardModel()
            {
                Id = x.Id,
                Title = x.Title,
                ScrumEvent = new ScrumEventModel() 
                {
                    Id = x.ScrumEvent.Id,
                    Name = x.ScrumEvent.Name
                },
                DateEnd = (DateTime)x.DateEnd,
                DateStart = (DateTime)x.DateStart
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, card);
        }

        public async Task<HttpResponseMessage> Post([FromBody] CardModel cardModel)
        {
            var card = new Card()
            {
                Title = cardModel.Title,
                DateEnd = cardModel.DateEnd,
                DateStart = cardModel.DateStart,
                ScrumEventId = cardModel.ScrumEvent.Id
            };

            _ent.Card.Add(card);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, card.Id);

        }


    }
}
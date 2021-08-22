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
    public class ClientController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public ClientController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] ClientModel clientModel)
        {
            var client = new Client()
            {
                FirstName = clientModel.FirstName,
                MiddleName = clientModel.MiddleName,
                LastName = clientModel.LastName,
                Email = clientModel.Email,
                Phone = clientModel.Phone
            };

            _ent.Client.Add(client);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, client.Id);
        }

        public async Task<HttpResponseMessage> Get() 
        {
            var clients = await _ent.Client.Select(x => new ClientModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, clients);
        }
    }
}
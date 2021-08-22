using CrmHackApi.Helper;
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
    public class OrderController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public OrderController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] OrderModel orderModel)
        {
            var order = new Order()
            {
                ClientId = orderModel.Client.Id,
                DateCreated = DateTime.Now,
                WorkerId = null,
                StatusId = 1
            };

            _ent.Order.Add(order);
            await _ent.SaveChangesAsync();

            PermanentData.Order = order;

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> Put([FromBody] OrderModel orderModel)
        {
            var order = await _ent.Order.FindAsync(orderModel.Id);

            if (order != null) 
            {
                order.StatusId = orderModel.Status.Id;
                order.WorkerId = orderModel.Worker.Id;

                await _ent.SaveChangesAsync();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, order.Id);
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Заказ не был найден");

        }
    }
}
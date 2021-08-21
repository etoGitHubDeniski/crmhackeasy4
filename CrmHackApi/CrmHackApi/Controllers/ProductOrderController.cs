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
    public class ProductOrderController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public ProductOrderController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] ProductOrderModel productOrderModel)
        {
            var productOrder = new ProductOrder()
            {
                ProductId = productOrderModel.Product.Id,
                OrderId = productOrderModel.Order.Id
            };

            _ent.ProductOrder.Add(productOrder);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> Get()
        {

            var productOrder = await _ent.ProductOrder.Select(x => new ProductOrderModel()
            {
                Product = new ProductModel()
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Price = (decimal)x.Product.Price,
                    Category = new CategoryModel()
                    {
                        Id = x.Product.Category.Id,
                        Name = x.Product.Category.Name
                    }
                },
                Order = new OrderModel()
                {
                    Client = new ClientModel()
                    {
                        Id = x.Order.Client.Id,
                        FirstName = x.Order.Client.FirstName,
                        MiddleName = x.Order.Client.MiddleName,
                        LastName = x.Order.Client.LastName,
                        Email = x.Order.Client.Email,
                        Phone = x.Order.Client.Phone
                    },
                    Worker = new WorkerModel()
                    {
                        Id = x.Order.Worker.Id,
                        FirstName = x.Order.Worker.FirstName,
                        MiddleName = x.Order.Worker.MiddleName,
                        LastName = x.Order.Worker.LastName,
                        Email = x.Order.Worker.Email,
                        Phone = x.Order.Worker.Phone
                    },
                    Status = new StatusModel()
                    {
                        Id = x.Order.Status.Id,
                        Name = x.Order.Status.Name
                    },
                    DateCreated = (DateTime)x.Order.DateCreated
                }
            }).ToListAsync();           

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, productOrder);
        }

    }
}
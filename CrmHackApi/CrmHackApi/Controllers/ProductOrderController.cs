using CrmHackApi.Helper;
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
        private List<ProductOrderModel> _productOrder { get; set; }
        private List<ProductOrderWorkerModel> _productOrderWorker { get; set; }

        public ProductOrderController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] ProductOrderModel productOrderModel)
        {
            var productOrder = new ProductOrder()
            {
                ProductId = productOrderModel.Product.Id,
                OrderId = PermanentData.Order.Id
            };

            _ent.ProductOrder.Add(productOrder);
            await _ent.SaveChangesAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> Get()
        {

            _productOrder = await _ent.ProductOrder.Select(x => new ProductOrderModel()
            {
                Id = x.Id,
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

            await Task.Factory.StartNew(RecommendWorker);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, _productOrderWorker);
        }


        private async Task RecommendWorker()
        {
            _productOrderWorker = new List<ProductOrderWorkerModel>();

            foreach (var productOrder in _productOrder)
            {
                if (productOrder.Order.Worker.Id == null)
                {
                    var categoryWorker = _productOrder
                        .Where(x => x.Product.Category.Id == productOrder.Product.Category.Id)
                        .Select(x => x.Order.Worker)
                        .ToList();

                    var neededId = categoryWorker
                        .Where(x => x.Id != null)
                        .GroupBy(x => x.Id)
                        .OrderByDescending(y => y.Count())
                        .Select(x => x.Key)
                        .First();

                    var worker = _ent.Worker.Find(neededId);
                    string recommended = $"{worker.MiddleName} {worker.FirstName} {worker.LastName}";

                    _productOrderWorker.Add(new ProductOrderWorkerModel()
                    {
                        ProductOrder = productOrder,
                        RecommendedWorker = recommended
                    });
                }
                else
                {
                    if (productOrder.Order.Status.Id != 1)
                    {
                        _productOrderWorker.Add(new ProductOrderWorkerModel()
                        {
                            ProductOrder = productOrder,
                            RecommendedWorker = string.Empty
                        });
                    }

                }
            }
        }
    }
}

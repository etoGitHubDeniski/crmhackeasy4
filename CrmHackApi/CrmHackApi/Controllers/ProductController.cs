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
    public class ProductController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public ProductController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Get() 
        {
            var product = await _ent.Product.Select(x => new ProductModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = (decimal)x.Price,
                Category = new CategoryModel() 
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name
                }
            }).ToListAsync();

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, product);
        }
    }
}
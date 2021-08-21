﻿using CrmHackApi.Models;
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
    public class WorkerController : ApiController
    {
        private CrmHackEntities _ent { get; set; }

        public WorkerController()
        {
            _ent = new CrmHackEntities();
        }

        public async Task<HttpResponseMessage> Get(string login, string password)
        {
            var worker = await _ent.Worker.FirstOrDefaultAsync(x => x.Login == login
            && x.Password == password);

            if (worker != null)
            {
                var workerData = new WorkerModel()
                {
                    FirstName = worker.FirstName,
                    MiddleName = worker.MiddleName,
                    LastName = worker.LastName,
                    Email = worker.Email,
                    Role = new RoleModel()
                    {
                        Id = (int)worker.RoleId,
                        Name = worker.Role.Name
                    }                    
                };

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, workerData);
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Пользователь не найден");
        }
    }
}
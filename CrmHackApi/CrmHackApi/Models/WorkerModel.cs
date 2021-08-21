﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmHackApi.Models
{
    public class WorkerModel
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public RoleModel Role { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
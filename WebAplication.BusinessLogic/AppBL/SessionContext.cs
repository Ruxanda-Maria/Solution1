﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplication.Domain.Entities.User;

namespace WebAplication.BusinessLogic.AppBL
{
    public class SessionContext : DbContext
    {
        public SessionContext() :
            base("name=WebApplication")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}

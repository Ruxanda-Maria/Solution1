﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.Extension
{
    public static class HttpContextExtencions
    {
        public static UserMinimal GetMySessionObject(this HttpContext current)
        {
            return (UserMinimal)current?.Session["__SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Models
{
     public class AddUser
     {
          public string Username { get; set; }

          public string Password { get; set; }

          public DateTime LastLogin { get; set; }

          public string LastIp { get; set; }

          public URole Level { get; set; }

          public string Image { get; set; }
     }
}
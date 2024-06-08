using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.Admin
{
     public class AddUserData
     {
          public string Username { get; set; }

          public string Password { get; set; }

          public DateTime LastLogin { get; set; }

          public string LastIp { get; set; }

          public URole Level { get; set; }

          public string Image { get; set; }
     }
}

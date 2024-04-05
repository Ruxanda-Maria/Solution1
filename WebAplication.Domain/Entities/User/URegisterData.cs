using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAplication.Domain.Entities.User
{
    public class URegisterData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LoginIP { get; set; }
        public DateTime LoginDataTime { get; set; }
    }
}

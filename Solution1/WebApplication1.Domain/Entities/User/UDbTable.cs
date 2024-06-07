using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Last Login")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Last Ip")]
        public string LastIp { get; set; }

        [Display(Name = "Level")]
        public URole Level { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}

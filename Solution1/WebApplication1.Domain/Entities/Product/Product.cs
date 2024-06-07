using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Product
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Time Added")]
        public DateTime AddedTime { get; set; }

        [Display(Name = "Bought")]
        public int Bought { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "XS")]
        public bool XS { get; set; }

        [Display(Name = "S")]
        public bool S { get; set; }

        [Display(Name = "M")]
        public bool M { get; set; }

        [Display(Name = "L")]
        public bool L { get; set; }

        [Display(Name = "XL")]
        public bool XL { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}

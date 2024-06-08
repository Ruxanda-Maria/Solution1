using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.Admin
{
     public class AddProductData
     {
          public string Name { get; set; }

          public string Image { get; set; }

          public string Type { get; set; }

          public decimal Price { get; set; }

          public DateTime AddedTime { get; set; }

          public int Bought { get; set; }

          public string Category { get; set; }

          public bool XS { get; set; }

          public bool S { get; set; }

          public bool M { get; set; }

          public bool L { get; set; }

          public bool XL { get; set; }

          public string Description { get; set; }
     }
}

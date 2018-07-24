using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        //String length max 20
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Category { get; set; }
    }
}

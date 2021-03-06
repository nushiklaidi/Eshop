﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Models
{
    public class Product : BaseEntity
    {
        //String length max 20
        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        //Numeric range for the value of data field
        [Range(0, 1000)]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }
        
    }
}

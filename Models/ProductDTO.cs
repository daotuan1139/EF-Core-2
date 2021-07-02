using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace EF_Core_2.Models
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string Manifacture { get; set; }

    }
}
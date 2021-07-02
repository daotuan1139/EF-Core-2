using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace EF_Core_2.Models
{

    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [MaxLength(100)]
        public string Manifacture { get; set; }

        public int CategoryId {get; set;}
        public Category Category {get; set;}

    }
}
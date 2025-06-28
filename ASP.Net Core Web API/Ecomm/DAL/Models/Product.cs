﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("ProductId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ProductId { get; set; }

        [Column("ProductName")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        [Required]
        public string ProductName { get; set; }

        [Column("Category")]
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Category { get; set; }

        [Column("ListPrice")]
        [Required]
        public double ListPrice { get; set; }
    }
}
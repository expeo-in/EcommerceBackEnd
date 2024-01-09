﻿using System.ComponentModel.DataAnnotations;

namespace EcommerceBackEnd.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public int Qty { get; set; }
        
        [StringLength(250)]
        public string ImageUrl { get; set; }
        
        public bool IsActive { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClothZone.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }
        [Required,MinLength(4,ErrorMessage="Minimum length is 4")]
        public string Description { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="Please enter a value")]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }  
        public int CategoryId { get; set; }    
        public string Image { get; set; }  
        public string Size { get; set; }
        public Category Category { get; set; }

    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
    }
}

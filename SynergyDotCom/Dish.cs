using System;
using System.ComponentModel.DataAnnotations;

namespace SynergyDotCom.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Title { get; set; }       // Added to fix error

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        // Added these to fix your "missing definition" errors
        public string? Category { get; set; }
        public string? Region { get; set; }
        public string? PrepTime { get; set; }
        public string? Difficulty { get; set; }
        public string? Ingredients { get; set; }
        public string? Method { get; set; }
    }
}
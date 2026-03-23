using System;
using System.ComponentModel.DataAnnotations;

namespace SynergyDotCom.Models
{
    public class Poem
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Poet { get; set; }
        public string? Author { get; set; }  // Added to fix error

        public string? Content { get; set; }
        public string? Body { get; set; }    // Added to fix error

        public DateTime Date { get; set; } = DateTime.Now;
        public DateTime PublishedDate { get; set; } = DateTime.Now; // Added to fix error

        public string? Theme { get; set; }   // Added to fix error
        public string? Excerpt { get; set; } // Added to fix error
        public string? ImageUrl { get; set; } // Added to fix error
    }
}
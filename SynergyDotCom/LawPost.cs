using System;
using System.ComponentModel.DataAnnotations;

namespace SynergyDotCom.Models
{
    public class LawPost
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? LegalCategory { get; set; } // e.g., "Property Law"
        public string? CaseReference { get; set; } // e.g., "Suit No: SC/12/2024"
        public string? Analysis { get; set; }      // Your breakdown of the law
        public string? ImageUrl { get; set; }

        // Added Body/Content just in case other pages try to access them by different names
        public string? Body { get; set; }
        public string? Content { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
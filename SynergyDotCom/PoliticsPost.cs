using System;
using System.ComponentModel.DataAnnotations;

namespace SynergyDotCom.Models
{
    public class PoliticsPost
    {
        public int Id { get; set; }

        [Required]
        public string? Headline { get; set; }

        public string? Source { get; set; }
        public string? Body { get; set; }
        public string? ImageUrl { get; set; }

        // This is the property causing your error. It must be here!
        public DateTime Date { get; set; } = DateTime.Now;

        // Extra fields to match your other errors
        public string? Summary { get; set; }
        public string? FullStory { get; set; }
        public bool IsBreakingNews { get; set; }
    }
}
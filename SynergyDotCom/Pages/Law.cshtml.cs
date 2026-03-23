using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynergyDotCom.Pages
{
    public class LawModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LawModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // The list that holds your data
        public IList<LawPost> LawPosts { get; set; } = new List<LawPost>();

        public async Task OnGetAsync()
        {
            if (_context.LawPosts != null)
            {
                // Fetch ALL posts, sorted by newest first
                LawPosts = await _context.LawPosts
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
        }
    }
}
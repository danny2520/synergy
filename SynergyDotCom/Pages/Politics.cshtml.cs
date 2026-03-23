using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;
using System.Collections.Generic;
using System.Linq; // Added for OrderByDescending
using System.Threading.Tasks;

namespace SynergyDotCom.Pages
{
    public class PoliticsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PoliticsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PoliticsPost> PoliticsPosts { get; set; } = new List<PoliticsPost>();

        public async Task OnGetAsync()
        {
            if (_context.PoliticsPosts != null)
            {
                PoliticsPosts = await _context.PoliticsPosts
                    .OrderByDescending(p => p.Id)
                    .ToListAsync();
            }
        }
    }
}
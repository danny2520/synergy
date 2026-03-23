using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyDotCom.Pages
{
    public class AnthologyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AnthologyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Poem> Poems { get; set; } = new List<Poem>();

        public async Task OnGetAsync()
        {
            if (_context.Poems != null)
            {
                Poems = await _context.Poems.OrderByDescending(p => p.Id).ToListAsync();
            }
        }
    }
}
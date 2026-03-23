using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyDotCom.Pages
{
    public class CulinaryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CulinaryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dishes { get; set; } = new List<Dish>();

        public async Task OnGetAsync()
        {
            if (_context.Dishes != null)
            {
                Dishes = await _context.Dishes.OrderByDescending(d => d.Id).ToListAsync();
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyDotCom.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Culinary Section (Using 'Dish')
        public IList<Dish> FeaturedDishes { get; set; } = new List<Dish>();

        // 2. Anthology Section (Using 'Poem')
        public IList<Poem> RecentPoems { get; set; } = new List<Poem>();

        // 3. Politics Section (Using 'PoliticsPost')
        public IList<PoliticsPost> RecentPolitics { get; set; } = new List<PoliticsPost>();

        // 4. Law Section (Using 'LawPost')
        public IList<LawPost> RecentLawPosts { get; set; } = new List<LawPost>();

        public async Task OnGetAsync()
        {
            // Fetch Dishes
            if (_context.Dishes != null)
            {
                FeaturedDishes = await _context.Dishes
                    .OrderByDescending(d => d.Id)
                    .Take(3)
                    .ToListAsync();
            }

            // Fetch Poems
            if (_context.Poems != null)
            {
                RecentPoems = await _context.Poems
                    .OrderByDescending(p => p.Id)
                    .Take(3)
                    .ToListAsync();
            }

            // Fetch Politics (Was 'NewsItems', now 'PoliticsPosts')
            if (_context.PoliticsPosts != null)
            {
                RecentPolitics = await _context.PoliticsPosts
                    .OrderByDescending(p => p.Id)
                    .Take(3)
                    .ToListAsync();
            }

            // Fetch Law (Was 'LawArticles', now 'LawPosts')
            if (_context.LawPosts != null)
            {
                RecentLawPosts = await _context.LawPosts
                    .OrderByDescending(l => l.Id)
                    .Take(3)
                    .ToListAsync();
            }
        }
    }
}
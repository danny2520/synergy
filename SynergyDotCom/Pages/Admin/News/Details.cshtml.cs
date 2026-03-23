using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Admin.News
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PoliticsPost PoliticsPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicspost = await _context.PoliticsPosts.FirstOrDefaultAsync(m => m.Id == id);
            if (politicspost == null)
            {
                return NotFound();
            }
            else
            {
                PoliticsPost = politicspost;
            }
            return Page();
        }
    }
}
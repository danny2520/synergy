using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.News
{
    public class DeleteModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public DeleteModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var politicspost = await _context.PoliticsPosts.FindAsync(id);
            if (politicspost != null)
            {
                PoliticsPost = politicspost;
                _context.PoliticsPosts.Remove(PoliticsPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.Law
{
    public class DeleteModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public DeleteModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LawPost LawPost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawpost = await _context.LawPosts.FirstOrDefaultAsync(m => m.Id == id);

            if (lawpost == null)
            {
                return NotFound();
            }
            else
            {
                LawPost = lawpost;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawpost = await _context.LawPosts.FindAsync(id);
            if (lawpost != null)
            {
                LawPost = lawpost;
                _context.LawPosts.Remove(LawPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

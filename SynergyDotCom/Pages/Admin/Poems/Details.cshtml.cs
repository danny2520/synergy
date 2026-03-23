using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.Poems
{
    public class DetailsModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public DetailsModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Poem Poem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poem = await _context.Poems.FirstOrDefaultAsync(m => m.Id == id);
            if (poem == null)
            {
                return NotFound();
            }
            else
            {
                Poem = poem;
            }
            return Page();
        }
    }
}

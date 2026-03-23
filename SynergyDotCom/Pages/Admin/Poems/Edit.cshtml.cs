using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.Poems
{
    public class EditModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public EditModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Poem Poem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poem =  await _context.Poems.FirstOrDefaultAsync(m => m.Id == id);
            if (poem == null)
            {
                return NotFound();
            }
            Poem = poem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Poem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoemExists(Poem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PoemExists(int id)
        {
            return _context.Poems.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.Law
{
    public class CreateModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public CreateModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LawPost LawPost { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LawPosts.Add(LawPost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

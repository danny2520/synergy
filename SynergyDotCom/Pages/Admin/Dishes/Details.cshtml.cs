using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Data;
using SynergyDotCom.Models;

namespace SynergyDotCom.Pages.Shared.Admin.Dishes
{
    public class DetailsModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public DetailsModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes.FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            else
            {
                Dish = dish;
            }
            return Page();
        }
    }
}

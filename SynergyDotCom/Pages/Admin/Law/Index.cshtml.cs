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
    public class IndexModel : PageModel
    {
        private readonly SynergyDotCom.Data.ApplicationDbContext _context;

        public IndexModel(SynergyDotCom.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LawPost> LawPost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            LawPost = await _context.LawPosts.ToListAsync();
        }
    }
}

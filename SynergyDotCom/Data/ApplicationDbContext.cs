using Microsoft.EntityFrameworkCore;
using SynergyDotCom.Models;
using System.Collections.Generic;

namespace SynergyDotCom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 1. Culinary Section
        public DbSet<Dish> Dishes { get; set; }

        // 2. Anthology Section
        public DbSet<Poem> Poems { get; set; }

        // 3. Politics Section
        public DbSet<PoliticsPost> PoliticsPosts { get; set; }

        // 4. Law Section
        public DbSet<LawPost> LawPosts { get; set; }
    }
}
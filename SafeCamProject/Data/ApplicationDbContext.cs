using Microsoft.EntityFrameworkCore;
using SafeCamProject.Models;

namespace SafeCamProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Profession> Professions { get; set; }
    }
}

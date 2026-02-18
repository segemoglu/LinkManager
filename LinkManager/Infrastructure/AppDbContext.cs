using LinkManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkManager.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LinkItem> Links { get; set; } // Veritabanındaki tablomuz

        public DbSet<User> Users { get; set; }
    }
}
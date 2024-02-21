using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Company> Companies { get; set; }
    }
}

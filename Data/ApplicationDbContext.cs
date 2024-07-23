using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using _2Good2EatBackendStore.Data.Entities;

namespace _2Good2EatBackendStore.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

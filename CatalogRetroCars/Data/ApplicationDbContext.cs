using CatalogRetroCars.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatalogRetroCars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<RetroCar> RetroCars { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using CL_InterfaceAdapters_Models;
namespace CL_InterfaceAdapters_Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        { }

        public DbSet<BeerModel> Beers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>().ToTable("Beer");
        }
    }
}

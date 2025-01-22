using CountriesApiProject.Models.Countries;
using Microsoft.EntityFrameworkCore;

namespace CountriesApiProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) :
            base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CountryConfiguration());
        }

        public DbSet<Country> Countries {  get; set; }
    }
}

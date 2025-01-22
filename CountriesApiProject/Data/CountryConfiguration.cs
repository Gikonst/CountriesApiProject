using CountriesApiProject.Models.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CountriesApiProject.Data
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("CountryName");

            builder.Property(x => x.Capital)
                .HasMaxLength(1000)
                .HasColumnName("Capital")
                .HasConversion(
                    v => string.Join(",", v ?? new List<string>()), 
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() 
                );

            builder.Property(x => x.Borders)
                .HasMaxLength(2000)
                .HasColumnName("Borders")
                .HasConversion(
                    v => string.Join(",", v ?? new List<string>()), 
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() 
                );

            builder.ToTable("Countries");
        }
    }
}

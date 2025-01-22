using CountriesApiProject.Models.Countries;

namespace CountriesApiProject.Mappers
{
    public static class CountryMappers
    {
        public static Country MapToModel(CountryDTO dto)
        {
            return new Country
            {
                Name = dto.Name?.Common ?? "Unknown", // Flatten CountryName
                Capital = dto.Capital ?? new List<string>(), // Assign List<string> directly
                Borders = dto.Borders ?? new List<string>()
            };
        }
        public static CountryDTO MapToDTO(Country country)
        {
            return new CountryDTO
            {
                Name = new CountryName { Common = country.Name },
                Capital = country.Capital ?? new List<string>(), 
                Borders = country.Borders ?? new List<string>()
            };
        }
    }


}

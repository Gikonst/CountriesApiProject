using CountriesApiProject.Models.Countries;

namespace CountriesApiProject.Interfaces.Countries
{
    public interface ICountriesService
    {
        public Task<List<CountryDTO>> GetCountriesAsync();
    }
}

using CountriesApiProject.Data;
using CountriesApiProject.Interfaces.Countries;
using CountriesApiProject.Mappers;
using CountriesApiProject.Models.Countries;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace CountriesApiProject.Services.Countries
{
    public class CountriesService : ICountriesService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _dbContext;
        private readonly ICacheService _cacheService;
        private const string CacheKey = "countriesCacheKey";

        public CountriesService(HttpClient httpClient, ApplicationDbContext dbContext, ICacheService cacheService)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        public async Task<List<CountryDTO>> GetCountriesAsync()
        {
            try
            {
                var cachedCountries = await _cacheService.GetAsync<List<CountryDTO>>(CacheKey);
                if (cachedCountries != null)
                {
                    return cachedCountries;
                }

                var countriesFromDb = await _dbContext.Countries.ToListAsync();
                if (countriesFromDb.Any())
                {

                    var countryDTOs = countriesFromDb.Select(CountryMappers.MapToDTO).ToList();
                    await _cacheService.SetAsync(CacheKey, countryDTOs);
                    return countryDTOs;
                }

                string apiUrl = "https://restcountries.com/v3.1/all?fields=name,capital,borders";
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                
                var result = JsonConvert.DeserializeObject<List<CountryDTO>>(content);

                if (result == null || !result.Any())
                {
                    throw new InvalidOperationException("Failed to deserialize country data.");
                }

                var countriesToSave = result.Select(CountryMappers.MapToModel).ToList();
                await _dbContext.Countries.AddRangeAsync(countriesToSave);
                await _dbContext.SaveChangesAsync();

                
                await _cacheService.SetAsync(CacheKey, result);

                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Http error in CountriesService: {ex.Message}");
                throw;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON deserialization error in CountriesService: {jsonEx.Message}");
                throw new InvalidOperationException("Error deserializing country data.", jsonEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error in CountriesService: {ex.Message}");
                throw;
            }
        }
    }
}

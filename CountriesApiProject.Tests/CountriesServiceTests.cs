using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CountriesApiProject.Data;
using CountriesApiProject.Interfaces.Countries;
using CountriesApiProject.Models.Countries;
using CountriesApiProject.Services.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;

namespace CountriesApiProject.Tests
{
    public class CountriesServiceTests
    {
        private readonly Mock<HttpClient> _httpClientMock;
        private readonly Mock<ICacheService> _cacheServiceMock;
        private readonly ApplicationDbContext _dbContext;
        private readonly CountriesService _countriesService;

        public CountriesServiceTests()
        {
            
            _httpClientMock = new Mock<HttpClient>();
            _cacheServiceMock = new Mock<ICacheService>();

            _countriesService = new CountriesService(_httpClientMock.Object, _dbContext, _cacheServiceMock.Object);
        }

        [Fact]
        public async Task GetCountriesAsync_ReturnsCachedCountries_WhenCacheIsNotNull()
        {
            // Arrange
            var cachedCountries = new List<CountryDTO>
            {
                new CountryDTO { Name = new CountryName { Common = "Country1" }, Capital = new List<string> { "Capital1" }, Borders = new List<string> { "Border1" } }
            };
            _cacheServiceMock.Setup(c => c.GetAsync<List<CountryDTO>>("countriesCacheKey")).ReturnsAsync(cachedCountries);

            // Act
            var result = await _countriesService.GetCountriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result?.Count);
            Assert.Equal("Country1", result?[0].Name?.Common);
        }
    }
}


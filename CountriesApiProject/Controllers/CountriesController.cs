using CountriesApiProject.Interfaces.Countries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var result = await _countriesService.GetCountriesAsync();

                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Issue communicating with the third party APIs : {ex.Message}\n{ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error occured: {ex.Message}");
            }
        }
    }
}

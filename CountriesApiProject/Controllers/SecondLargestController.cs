using CountriesApiProject.Interfaces.SecondLargest;
using CountriesApiProject.Models.SecondLargest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondLargestController : ControllerBase
    {
        private readonly ISecondLargestService _secondLargestService;

        public SecondLargestController(ISecondLargestService secondLargestService)
        {
            _secondLargestService = secondLargestService;
        }

        [HttpPost]

        public async Task<IActionResult> GetSecondLargest([FromBody] RequestObj numberArray)
        {
            try
            {
                var result = await _secondLargestService.SecondLargestAsync(numberArray);

                if (result == null)
                {
                    return BadRequest("The array provided was empty. Please provide an array with at least one integer.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}

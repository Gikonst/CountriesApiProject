using CountriesApiProject.Interfaces;
using CountriesApiProject.Interfaces.SecondLargest;
using CountriesApiProject.Models.SecondLargest;

namespace CountriesApiProject.Services.SecondLargest
{
    public class SecondLargestService : ISecondLargestService
    {
        public Task<int?> SecondLargestAsync(RequestObj? numberArray)
        {
            try
            {
                if (numberArray?.RequestArrayObj == null || !numberArray.RequestArrayObj.Any())
                    return Task.FromResult<int?>(null);

                int largest = int.MinValue;
                int secondLargest = int.MinValue;
                bool secondLargestFound = false;

                foreach (int number in numberArray.RequestArrayObj)
                {
                    if (number > largest)
                    {
                        secondLargest = largest;
                        largest = number;
                        secondLargestFound = true;
                    }
                    else if (number > secondLargest && number < largest)
                    {
                        secondLargest = number;
                        secondLargestFound = true;
                    }
                }
                return Task.FromResult<int?>(secondLargestFound ? secondLargest : null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error in SecondLargestService: {ex.Message}");
                throw;
            }
        }
    }
}

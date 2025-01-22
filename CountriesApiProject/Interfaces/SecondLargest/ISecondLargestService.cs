using CountriesApiProject.Models.SecondLargest;

namespace CountriesApiProject.Interfaces.SecondLargest
{
    public interface ISecondLargestService
    {
        public Task<int?> SecondLargestAsync(RequestObj numberArray);
    }
}

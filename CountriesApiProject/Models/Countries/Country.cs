using Newtonsoft.Json;

namespace CountriesApiProject.Models.Countries
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string>? Capital { get; set; }
        public List<string>? Borders { get; set; } 
    }
}

using Newtonsoft.Json;

namespace CountriesApiProject.Models.Countries
{
    public class CountryDTO
    {
        [JsonProperty("name")]
        public CountryName? Name { get; set; }
        [JsonProperty("capital")]
        public List<string>? Capital { get; set; }
        [JsonProperty("borders")]
        public List<string>? Borders { get; set; }
    }
}

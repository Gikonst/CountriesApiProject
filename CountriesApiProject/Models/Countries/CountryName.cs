using Newtonsoft.Json;

namespace CountriesApiProject.Models.Countries
{
    public class CountryName
    {
        [JsonProperty("common")]
        public string? Common { get; set; }

    }
}

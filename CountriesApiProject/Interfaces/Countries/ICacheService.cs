namespace CountriesApiProject.Interfaces.Countries
{
    public interface ICacheService
    {
        public Task<T?> GetAsync<T>(string key);
        public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    }
}

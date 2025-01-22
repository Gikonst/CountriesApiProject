using CountriesApiProject.Interfaces.Countries;
using Microsoft.Extensions.Caching.Memory;

namespace CountriesApiProject.Services.Countries
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            return await Task.FromResult(_cache.TryGetValue(key, out T? value) ? value : default);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions();

            if (expiration.HasValue)
            {
                cacheEntryOptions.SetAbsoluteExpiration(expiration.Value);
            }

            await Task.Run(() => _cache.Set(key, value, cacheEntryOptions));
        }
    }
}

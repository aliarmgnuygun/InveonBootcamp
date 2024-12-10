using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace LibraryManagementApi.Services
{
    public class RedisCacheService(IDistributedCache _cache)
    {
        public async Task<ServiceResult<T?>> GetFromCacheAsync<T>(string key)
        {
            try
            {
                var cachedData = await _cache.GetAsync(key);

                if (cachedData == null)
                    return ServiceResult<T?>.Fail($"No data found in cache for key: {key}");

                var jsonData = Encoding.UTF8.GetString(cachedData);
                var result = JsonSerializer.Deserialize<T>(jsonData);

                return ServiceResult<T?>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<T?>.Fail($"An error occurred while accessing cache");
            }
        }

        public async Task SetToCacheAsync<T>(string key, T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var encodedData = Encoding.UTF8.GetBytes(jsonData);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
            await _cache.SetAsync(key, encodedData, options);
        }
    }
}

using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text;
using System.Text.Json;

namespace LibraryManagementApi.Services
{
    public class RedisCacheService(IDistributedCache _cache)
    {
        public async Task<T?> GetFromCacheAsync<T>(string key)
        {
            try
            {
                var cachedData = await _cache.GetAsync(key);
                if (cachedData == null) return default;

                var jsonData = Encoding.UTF8.GetString(cachedData);
                return JsonSerializer.Deserialize<T>(jsonData);
            }
            catch (RedisConnectionException ex)
            {
                throw new RedisException("Redis connection failed. Please try again later.");
            }
            catch (RedisTimeoutException ex)
            {
                throw new RedisException("Redis request timed out. Please try again.");
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

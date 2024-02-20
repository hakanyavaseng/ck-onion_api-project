using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnionAPI.Application.Interfaces.RedisCache;
using StackExchange.Redis;

namespace OnionAPI.Infrastructure.RedisCache
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly IDatabase database;
        private readonly RedisCacheSettings settings;

        public RedisCacheService(IOptions<RedisCacheSettings> options)
        {
            settings = options.Value;
            ConfigurationOptions? opt = ConfigurationOptions.Parse(settings.ConnectionString);
            redisConnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(string key)
        {
            RedisValue value = await database.StringGetAsync(key);
            if (value.HasValue)
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }
        public async Task SetAsync<T>(string key, T value, DateTime? expirationDateTime)
        {
            if(expirationDateTime is not null)
            {
                TimeSpan timeUnitExpiration = expirationDateTime.Value - DateTime.Now;
                await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);
            }
        }
    }
}

using Microsoft.Extensions.Options;

using StackExchange.Redis;

namespace RedisMvcApp.Configuration;

static class StackExchangeRedisExtension
{
    public static void AddStackExchangeRedis(this IServiceCollection services, Action<RedisConfig> configure)
    {
        services.Configure(configure);
        services.AddSingleton<ConnectionMultiplexer>(serviceProvider =>
        {
            var redisConfig = serviceProvider.GetService<IOptions<RedisConfig>>();
            return ConnectionMultiplexer.Connect(redisConfig.Value.Servers);
        });
    }
}

class RedisConfig
{
    public string? Servers { get; set; }

}
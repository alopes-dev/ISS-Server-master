using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ISWebLib
{
    public static class RedisDistributedCacheExtensions
    {
        public static IServiceCollection AddDistributedCacheService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:ConnectionString"];
                options.InstanceName = configuration["Redis:Instance"];
            }).AddSingleton<IDistributedCacheService, RedisDistributedCacheService>();

            return services;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace Hahn.Cache.Redis
{
    public static class Extensions
    {
        public static void AddRredisConfiguration(this IServiceCollection services, RedisConfiguration redisConfiguration)
        {

           
            services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

        }
    }
}

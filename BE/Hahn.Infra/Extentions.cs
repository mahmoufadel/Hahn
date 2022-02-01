using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Cache.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public static class Extensions
    {
        public static void AddInfra(this IServiceCollection services,IConfiguration Configuration)
        {
            //services.AddDbContext<EFCoreHahnContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<EFCoreHahnContext>(opts => opts.UseInMemoryDatabase(databaseName: "HahnDatabase"));

            //services.AddTransient<ICacheManager, RedisCacheManager>();
            services.AddTransient<ICacheManager, MemoryCacheManager>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));

            services.AddHttpClient("AssetService", config =>
                {
                    config.BaseAddress = new Uri(Configuration["AssetAPI"]);

                })
                ;
            services.AddTransient<IHttpService, HttpService>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.Cache.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicatonProcess.July2021.Application
{
    public static class Extensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
           
            services.AddTransient<IAssetService, AssetService>();
            services.AddTransient<IUserService, UserService>();
           

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

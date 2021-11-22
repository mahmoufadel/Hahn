using AutoMapper;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Cache.Redis;
using Hahn.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hahn.XTest.Mock;

namespace Hahn.XTest
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			//services.AddDbContext<EFCoreHahnContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<EFCoreHahnContext>(opts => opts.UseInMemoryDatabase(databaseName: "HahnDatabase"));


			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
			services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));


			services.AddTransient<IHttpService, MockHttpService>();
			services.AddTransient<IAssetService, AssetService>();
			services.AddTransient<IUserService, UserService>();
			//services.AddTransient<ICacheManager, RedisCacheManager>();
			services.AddTransient<ICacheManager, MemoryCacheManager>();


			services.AddDbContext<ApplicationDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "ApplicationDbContext"));
			//services.AddDbContext<ApplicationDbContext>(options =>	options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

		}
	}
}


using FluentMediator;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
//using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hahn.Identity.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using AutoMapper;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Hahn.Cache.Redis;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;

namespace Hahn.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			
			var redisConfiguration = Configuration.GetSection("Redis").Get<RedisConfiguration>();
			services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);

			//services.AddDbContext<EFCoreHahnContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<EFCoreHahnContext>(opts => opts.UseInMemoryDatabase(databaseName: "HahnDatabase"));

			
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
			services.AddScoped(typeof(IAssetRepository), typeof(AssetRepository));


			
			services.AddTransient<IHttpService, HttpService>();
			services.AddTransient<IAssetService, AssetService>();
			services.AddTransient<IUserService, UserService>();
			//services.AddTransient<ICacheManager, RedisCacheManager>();
			services.AddTransient<ICacheManager, MemoryCacheManager>();


			services.AddDbContext<ApplicationDbContext>(opts => opts.UseInMemoryDatabase(databaseName: "ApplicationDbContext"));
			//services.AddDbContext<ApplicationDbContext>(options =>	options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			

			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			});

			// Adding Authentication  
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})

			// Adding Jwt Bearer  
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = Configuration["JWT:ValidAudience"],
					ValidIssuer = Configuration["JWT:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
				};
			});


			/*services.AddFluentMediator(builder =>
			{
				builder.On<Inventory>().PipelineAsync().Call<ITransService>((handler, request) => handler.CreateTrans(request));
			});*/



			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddApplicationInsightsTelemetry();
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();




			app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentMediator;
using System.Threading.Tasks;
using Xunit;
using Hahn.Cache.Redis;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Repositories;
using Hahn.ApplicatonProcess.July2021.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.InMemory;
using Hahn.Identity.Model;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MTM.XTest.Services
{
    public class BaseServiceTests
    {
        public readonly IAssetRepository assetRepository;
        public readonly IUserRepository userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public readonly IMapper _mapper;
        public readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        public readonly ICacheManager cacheManager = new MemoryCacheManager();
        public readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();



        public BaseServiceTests()
        {
            

            

           

        }
        
       
        

	}
}

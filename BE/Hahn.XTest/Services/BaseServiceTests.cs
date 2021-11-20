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

namespace MTM.XTest.Services
{
    public class BaseServiceTests
    {
        public readonly IAssetRepository repository;
        public readonly IMapper _mapper;
        public readonly Mock<IMediator> _mockIMediator = new Mock<IMediator>();
        public readonly ICacheManager cacheManager = new MemoryCacheManager();
        public readonly Mock<IConfiguration> _configuration = new Mock<IConfiguration>();



        public BaseServiceTests()
        {
            var options = new DbContextOptionsBuilder<EFCoreHahnContext>()
                .UseInMemoryDatabase(databaseName: "HahnDatabase")
               .Options;

            var context = new EFCoreHahnContext(options);
            repository = new AssetRepository(_configuration.Object);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }



    }
}

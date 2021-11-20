using Moq;
using MTM.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentMediator;
using System.Threading.Tasks;
using Xunit;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.Application.Services.Inventory.Dto;

namespace MTM.XTest.Services
{
    public class AssetServiceTests : BaseServiceTests
    {
        private IAssetService assetService;
        public AssetServiceTests() : base()
        {
            assetService = new AssetService(repository, _mapper, cacheManager);
        }


        [Fact]
        public async Task Create_Success()
        {
            
        }

        
    }
}

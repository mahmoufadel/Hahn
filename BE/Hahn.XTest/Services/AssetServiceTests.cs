using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentMediator;
using System.Threading.Tasks;
using Xunit;
using Hahn.ApplicatonProcess.July2021.Application;


namespace MTM.XTest.Services
{
    public class AssetServiceTests : BaseServiceTests
    {
        private IAssetService _assetService;
        public AssetServiceTests(IAssetService assetService) : base()
        {
            _assetService = assetService;
        }


        [Fact]
        public async Task Create_Success()
        {
           var data= await _assetService.GetAll();
            Assert.NotNull(data);
        }

        
    }
}

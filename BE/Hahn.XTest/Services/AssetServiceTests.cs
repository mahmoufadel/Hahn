using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentMediator;
using System.Threading.Tasks;
using Xunit;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.Application.Services.Asset.Dto;

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

        [Fact]
        public async Task Validate_Success()
        {
            List<AssetDto> assets = new List<AssetDto>() { new AssetDto { Id = "As3", Name = "Asset 3", Symbol = "AST3" } };
            var res = await _assetService.Validate(assets);
            Assert.True(res);
        }

        [Fact]
        public async Task Validate_Fail()
        {
            List<AssetDto> assets = new List<AssetDto>() { new AssetDto { Id = "badId", Name = "Asset 3", Symbol = "AST3" } };
            var res = await _assetService.Validate(assets);
            Assert.False(res);
        }


    }
}

using Moq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentMediator;
using System.Threading.Tasks;
using Xunit;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Hahn.XTest;
using Hahn.Application.Services.Asset.Dto;

namespace MTM.XTest.Services
{
    public class UserServiceTests : BaseServiceTests
    {
        private IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserServiceTests(IUserService userService, UserManager<ApplicationUser> userManager) : base()
        {
            _userService = userService;
            _userManager = userManager;
            var user = _userManager.CreateAsync(MockObjects.user, MockObjects.Password).Result;
        }


        [Fact]
        public async Task Create_Success()
        {
            var user = await _userService.Get("fadel");

            Assert.Equal("fadel", user.FirstName);
        }
        [Fact]
        public async Task Check_Success()
        {
            var userExists = await _userManager.FindByNameAsync(MockObjects.user.FirstName);

            Assert.Equal(userExists.FirstName, MockObjects.user.FirstName);
        }
        [Fact]
        public async Task TrackAssets_Success()
        {
            var user = await _userService.TrackAssets(MockObjects.user.FirstName, MockObjects.assetDtos);

            Assert.Equal(user.Assets.Count, MockObjects.assetDtos.Count);
        }

        


    }
}

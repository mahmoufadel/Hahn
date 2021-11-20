using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTM.API.Controllers
{
	[ApiController]

	[Route("api/[controller]/[action]")]
	[Authorize]
	public class AssetController : ControllerBase
	{
		IAssetService  _assetService;
		IUserService _userService;
		public AssetController(IAssetService assetService, IUserService userService) 
		{
			_assetService = assetService;
			_userService = userService;
		}
		


		[HttpGet]
		[ActionName("GetAll")]		
		public async Task<List<AssetDto>> GetAll()
		{
			var user = await _userService.Get(User.Identity.Name);
			var assets= await _assetService.GetAll();
			assets.ForEach(asset => { asset.Tracked = user.Assets.Contains(asset); });

			return assets;

		}

		
	}
}

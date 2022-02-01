using Hahn.Application.Services.Asset.Dto;
using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Application;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users.Dto;
using Hahn.ApplicatonProcess.July2021.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTM.API.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/[controller]/[action]")]
	public class UserController : ControllerBase
	{
        readonly IUserService _userService;
		IAssetService _assetService;
		public UserController(IUserService userService, IAssetService assetService)
		{
			_userService = userService;
			_assetService = assetService;
		}

		

		[HttpGet]
		[ActionName("Get")]
		
		public async Task<UserDto> Get()
		{			
			return await _userService.Get(User.Identity.Name);
		}

		[HttpPost]
		[ActionName("TrackAssets")]
		
		public async Task<IActionResult> TrackAssets(List<AssetDto> assetDtos)
		{

			if (await _assetService.Validate(assetDtos))
			{
				return Ok(await _userService.TrackAssets(User.Identity.Name, assetDtos));
			}
			else return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "Assets is wrong , Please check Assets details and try again." });

		}


	}
}

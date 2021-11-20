using Hahn.Application.Services.Asset.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application
{
	public interface IAssetService
	{
		
		Task<AssetDto> Get(Guid Id);
		Task<List<AssetDto>> GetAll();

		Task<bool> Validate(List<AssetDto> assetDtos);

	}
}
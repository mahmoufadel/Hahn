using AutoMapper;
using Hahn.Application.Services.Asset.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using FluentMediator;
using StackExchange.Redis.Extensions.Core.Abstractions;
using Hahn.Cache.Redis;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.Cache;

namespace Hahn.ApplicatonProcess.July2021.Application
{
	public class AssetService : IAssetService
	{
		IAssetRepository _repository;
		
		private readonly IMapper _mapper;
		private readonly ICacheManager _cache;
		public AssetService(IAssetRepository repository, IMapper mapper,ICacheManager cacheManager) {
			_repository = repository;			
			_mapper = mapper;
			_cache = cacheManager;
		}


		public async Task Create(AssetDto assetDto)
		{
			await _cache.AddAsync(assetDto.Id.ToString(), assetDto);
			var asset = _mapper.Map<Asset>(assetDto);			
			await _repository.Create(asset);
			
		}

		public async Task<AssetDto> Get(Guid Id)
		{
			var ob=await _cache.GetAsync<AssetDto>(Id.ToString());
			if (ob != null)
				return ob;

			var res= await _repository.Get(Id);
			return _mapper.Map<AssetDto>(res);
		}

		public async Task<List<AssetDto>> GetAll()
		{
			var assetsFromCahce = await _cache.GetAsync<List<AssetDto>>(CacheKeys.GetAllAssetsKey());
			if (assetsFromCahce != null) return assetsFromCahce;

			var assets =await  _repository.GetAll();
			var assetsDto= _mapper.Map<List<AssetDto>>(assets);

			await _cache.AddAsync<List<AssetDto>>(CacheKeys.GetAllAssetsKey(), assetsDto);
			return assetsDto; 
		}

		public async Task<bool> Validate(List<AssetDto> assetDtos)
		{
			var allAssets = await this.GetAll();
			return assetDtos.Where(asset => allAssets.Contains(asset)).Count() == assetDtos.Count;			
		}

	}
}

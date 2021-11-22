using AutoMapper;
using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Cache.Redis;
using Hahn.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application.Services.Users
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICacheManager _cache;
       
        public UserService(IUserRepository repository, IMapper mapper, ICacheManager cacheManager
           )
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cacheManager;
           

        }
        public async Task<List<UserDto>> GetAll()
        {
           var users= await _repository.GetAll();
            return _mapper.Map<List<UserDto>>(users);
        }
        public async Task<UserDto> Get(string username)
        {
            var userFromCahce= await _cache.GetAsync<UserDto>(username);
            if (userFromCahce != null) return userFromCahce;
            
            var user = await _repository.Get(username);
            var userDto = _mapper.Map<UserDto>(user);

            await _cache.AddAsync(username,userDto);
            return userDto;
        }

        public async Task<UserDto> TrackAssets(string username,List<AssetDto> assetDtos)
        {           
            var userDto = await Get(username);           
            userDto.Assets=assetDtos;

            await _cache.AddAsync(username, userDto);
            return userDto;
        }

        
    }
}

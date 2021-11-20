
using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application.Services.Users
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> Get(string username);
        Task<UserDto> TrackAssets(string userName, List<AssetDto> assetDtos);
    }
}
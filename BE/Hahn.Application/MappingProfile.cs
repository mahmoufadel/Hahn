using AutoMapper;
using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Application.Services.Users;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<AssetDto, Asset>();
            CreateMap<Asset, AssetDto>();

            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();

            CreateMap<UserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();

        }
    }
}

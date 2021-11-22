using Hahn.Application.Services.Asset.Dto;
using Hahn.ApplicatonProcess.July2021.Domain;
using Hahn.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.XTest
{
    public static class MockObjects
    {
        public static string Password = "Otv@123";
        public static ApplicationUser user = new ApplicationUser()
        {
            Email = "fadel@fadel.com",
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = "fadel",
            LastName = "fadel",
            FirstName = "fadel",
            Address = new Address
            {
                AddressId = Guid.NewGuid(),
                HouseNumber = "123",
                PostalCode = "11711",
                Street = "23 fadel st"
            }
        };

        public static List<AssetDto> assetDtos = new List<AssetDto> {
            new AssetDto {Id="As1",Name="Asset 1",Symbol="AST1" },
        new AssetDto {Id="As2",Name="Asset 2",Symbol="AST2" },
        new AssetDto {Id="As3",Name="Asset 3",Symbol="AST3" },
        new AssetDto {Id="As4",Name="Asset 4",Symbol="AST4" },};


        public static List<Asset> assets = new List<Asset> {
            new Asset {Id="As1",Name="Asset 1",Symbol="AST1" },
        new Asset {Id="As2",Name="Asset 2",Symbol="AST2" },
        new Asset {Id="As3",Name="Asset 3",Symbol="AST3" },
        new Asset {Id="As4",Name="Asset 4",Symbol="AST4" },
         new Asset {Id="As5",Name="Asset 5",Symbol="AST5" },

          new Asset {Id="As6",Name="Asset 6",Symbol="AST6" },
           new Asset {Id="As7",Name="Asset 7",Symbol="AST7" },
            new Asset {Id="As8",Name="Asset 8",Symbol="AST8" },
        };
    }
}

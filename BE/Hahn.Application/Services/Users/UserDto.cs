using Hahn.Application.Services.Asset.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application.Services.Users
{
    public class UserDto
    {
        public UserDto() 
        {
            Assets = new List<AssetDto>();
        }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int? Age { get; set; }
        public AddressDto Address { get; set; }

        public List<AssetDto> Assets { get; set; }

    }

    public class AddressDto
    {
        [Required(ErrorMessage = "HouseNumber is required")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "PostalCode is required")]
        public string PostalCode { get; set; }
    }
}

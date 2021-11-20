using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Application.Services.Users.Dto
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public AddressDto Address { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 99, ErrorMessage = "Please enter a value Age greater than {1}")]
        public int Age { get; set; }

    }
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}

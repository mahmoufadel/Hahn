using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Hahn.Identity.Model
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        //public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
       
    }

    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AuthorBiography Biography { get; set; }
    }
    public class AuthorBiography
    {
        public int AuthorBiographyId { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Nationality { get; set; }
        public int AuthorRef { get; set; }
        public Author Author { get; set; }
    }
}


using Hahn.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July202.Identity
{
    public static class MockObjects
    {
        public static string Password = "Otv@123";
        public static ApplicationUser user = new ApplicationUser()
        {
            Email = "fadel@fadel.com",
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = "fadel",
            LastName = "Fadel",
            FirstName = "Mahmoud",
            Address = new Address
            {
                AddressId = Guid.NewGuid(),
                HouseNumber = "123",
                PostalCode = "11711",
                Street = "23 fadel st"
            }
        };

    }
}

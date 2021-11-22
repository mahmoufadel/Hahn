using Hahn.Identity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July202.Identity
{
    public static class MyIdentityDataInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync(MockObjects.user.UserName).Result == null)
            {
                IdentityResult result = userManager.CreateAsync(MockObjects.user, MockObjects.Password).Result;
            }



        }
    }
}

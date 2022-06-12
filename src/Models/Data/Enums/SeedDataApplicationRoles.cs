using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace News.Models.Data.Enums
{
    public static class SeedDataApplicationRoles
    {
        public static void SeedAspNetRoles(RoleManager<IdentityRole> roleManager)
        {
            List<string> roleList = new List<string>()
            {
                "Admin",
                "SuperAdmin",
                "User",
                "Authors"
            };

            foreach (var role in roleList)
            {
                var result =  roleManager.RoleExistsAsync(role).Result;
                if (!result)
                { 
                    roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
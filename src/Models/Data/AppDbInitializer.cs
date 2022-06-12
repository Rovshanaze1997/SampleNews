using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using News.Models.Data.Enums;
using News.Models.Static;

namespace News.Models.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
 
                context!.Database.EnsureCreated();

                if (!context.News.Any())
                {
                    context.News.AddRange(new List<News>()
                    {
                        new News()
                        {
                            Name = "Xeberin adi",
                            Content = "Xeberin metni",
                            Description = "Kicik metin",
                            PicUrl = "https://www.verdict.co.uk/wp-content/uploads/2020/06/Cloud-Computing-Timeline-2.jpg",
                            Categories = Categories.Computing,
                            DatePosted = DateTime.Now,
                         },
                        new News()
                        {
                            Name = "Hava haqda",
                            Content = "Bugun hava necedir?",
                            Description = "Hava haqqinda melumat",
                            PicUrl = "https://static01.nyt.com/images/2014/12/11/technology/personaltech/11machin-illo/11machin-illo-superJumbo-v3.jpg",
                            Categories = Categories.Weather,
                            DatePosted = DateTime.Today,
                        }
                    });
                    context.SaveChanges();
                }
                
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            AuthorName = "R",
                            AuthorAccountStatus = true,
                            AuthorDisplayName = "Rovshan",
                            AuthorEmail = "R@R.com",
                            AuthorProfile = "https://i.ibb.co/SskcGcS/Ads-z.png"
                        },
                   
                    });
                    context.SaveChanges();
                }
                
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Author))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Author));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@news.com";
                var adminUser = await userManager.FindByEmailAsync("admin@news.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "password12345");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                
                string appUserEmail = "user@news.com";
                var appUser = await userManager.FindByEmailAsync("user@news.com");
                if (adminUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "password12345");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
                
                string authorEmail = "author@news.com";
                var author = await userManager.FindByEmailAsync("author@news.com");
                if (author == null)
                {
                    var newAuthor = new ApplicationUser()
                    {
                        FullName = "Author",
                        UserName = "app-author",
                        Email = authorEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAuthor, "password12345");
                    await userManager.AddToRoleAsync(newAuthor, UserRoles.User);
                }
            }
        }
    }
}
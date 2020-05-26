using EsperiaHelp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsperiaHelp.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw) {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //creazione nomi delle aule
                if (!context.Classroom.Any())
                {
                    context.Classroom.AddRange(
                        new Classroom
                        {
                            Id=1,
                            Name="1-1"
                        },
                        new Classroom
                        {
                            Id = 2,
                            Name = "1-2"
                        },
                        new Classroom
                        {
                            Id = 3,
                            Name = "1-3"
                        },
                        new Classroom
                        {
                            Id = 4,
                            Name = "1-4"
                        },
                        new Classroom
                        {
                            Id = 5,
                            Name = "1-5"
                        }
                        );
                    context.SaveChanges();
                }


                //crezione account amministratori
                var adminID = await EnsureUser(serviceProvider, testUserPw, "cisana@itispaleocapa.it", "",context);
                await EnsureRole(serviceProvider, adminID, "Admin");

                //crezione account insegnanti
                var managerID = await EnsureUser(serviceProvider, testUserPw, "paola.ballini@itispaleocapa.it", "Italiano",context);
                await EnsureRole(serviceProvider, managerID, "Teacher");

                SeedDB(context, adminID);

            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName, string subject, ApplicationDbContext context)
        {

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                if (subject == "")
                {
                    user = new ApplicationUser
                    {
                        UserName = UserName,
                        EmailConfirmed = true,
                        Email = UserName
                    };
                }
                else
                {
                    foreach(var item in context.Subject)
                    {
                        if (item.Name == subject)
                        {
                            user = new ApplicationUser
                            {
                                UserName = UserName,
                                EmailConfirmed = true,
                                Email = UserName,
                                SubjectId=item.Id
                               
                            };
                        }
                    }
                }
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                              string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
        }



        } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.Seeders
{
	/// <summary>
	/// Extension methods for seeding empty database
	/// </summary>
	public static class DbSeeder
	{
		/// <summary>
		/// Initializes seeding
		/// </summary>
		/// <param name="dbContext">Injected dbContext</param>
		/// <param name="roleManager">Injected Role Manager</param>
		/// <param name="userManager">Injected User Manager</param>
		public static void Seed(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			if (!dbContext.Users.Any())
				CreateUsers(dbContext, roleManager, userManager).GetAwaiter().GetResult();
            if (!dbContext.Set<DoctorEmployment>().Any())
                CreateDoctorEmployments(dbContext).GetAwaiter().GetResult();

        }

        private static async Task CreateDoctorEmployments(ApplicationDbContext dbContext)
        {
            var clinics = new List<Clinic>
            {
                new Clinic
                {
                    Address = "Ul. Słoneczna 19",
                    City = "Warszawa",
                    Name = "Publiczna Przychodnia",
                    PostalCode = "00-000",
                    Province = "Mazowieckie",
                    CreatedBy = "Seeder"
                },
                new Clinic
                {
                    Address = "Ul. Nowa 33",
                    City = "Warszawa",
                    Name = "Prywatna Przychodnia",
                    PostalCode = "00-000",
                    Province = "Mazowieckie",
                    CreatedBy = "Seeder"
                }
            };
			
			var doctor = new Doctor
            {
				FirstName = "Jan",
				LastName = "Nowak",
				Title = "dr",
                CreatedBy = "Seeder"
            };

            await dbContext.AddRangeAsync(clinics);
            await dbContext.AddAsync(doctor);
            await dbContext.SaveChangesAsyncNoAudit();

            var employments = new List<DoctorEmployment>
            {
                new DoctorEmployment
                {
                    ClinicId = clinics[0].Id,
                    DoctorId = doctor.Id,
                    IsJobActive = false,
                    JobTitle = "Lekarz rodzinny",
                    CreatedBy = "Seeder"
                },
                new DoctorEmployment
                {
                    ClinicId = clinics[1].Id,
                    DoctorId = doctor.Id,
                    IsJobActive = true,
                    JobTitle = "Lekarz rodzinny",
                    CreatedBy = "Seeder"
                }
            };

            await dbContext.AddRangeAsync(employments);
            await dbContext.SaveChangesAsyncNoAudit();
        }

        /// <summary>
        /// Adds user roles and users to database
        /// </summary>
        /// <param name="context"></param>
        /// <param name="roleManager">Injected Role Manager</param>
        /// <param name="userManager">Injected User Manager</param>
        /// <returns></returns>
        private static async Task CreateUsers(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
            const string administratorRole = "Administrator";
            const string managerRole = "Manager";
			const string registeredUserRole = "RegisteredUser";

			if (!await roleManager.RoleExistsAsync(administratorRole))
				await roleManager.CreateAsync(new IdentityRole(administratorRole));

            if (!await roleManager.RoleExistsAsync(managerRole))
                await roleManager.CreateAsync(new IdentityRole(managerRole));

			if (!await roleManager.RoleExistsAsync(registeredUserRole))
				await roleManager.CreateAsync(new IdentityRole(registeredUserRole));

			var userAdmin = new ApplicationUser
            {
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = "Admin",
				Email = "admin@gmail.com",
                FirstName = "Admin",
				LastName =  "Admin"
			};
			var manager = new ApplicationUser
            {
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = "Manager",
				Email = "manager@gmail.com",
				FirstName = "Manager",
				LastName = "Manager"
            };
			var registeredUser = new ApplicationUser
            {
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = "User",
				Email = "user@gmail.com",
				FirstName = "User",
				LastName = "User"
            };

			if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
			{
				await userManager.CreateAsync(userAdmin, "Admin");
				await userManager.AddToRoleAsync(userAdmin, administratorRole);
				await userManager.AddToRoleAsync(userAdmin, managerRole);
				await userManager.AddToRoleAsync(userAdmin, registeredUserRole);
				userAdmin.EmailConfirmed = true;
				userAdmin.LockoutEnabled = false;
			}

            if (await userManager.FindByNameAsync(manager.UserName) == null)
            {
                await userManager.CreateAsync(manager, "Manager");
                await userManager.AddToRoleAsync(manager, managerRole);
                await userManager.AddToRoleAsync(manager, registeredUserRole);
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
			}

            if (await userManager.FindByNameAsync(registeredUser.UserName) == null)
            {
                await userManager.CreateAsync(registeredUser, "User");
                await userManager.AddToRoleAsync(registeredUser, registeredUserRole);
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }

            await context.SaveChangesAsyncNoAudit();
        }

	}
}
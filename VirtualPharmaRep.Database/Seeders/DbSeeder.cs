using System;
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
		}

		/// <summary>
		/// Adds user roles and admin user to database
		/// </summary>
		/// <param name="dbContext">Injected dbContext</param>
		/// <param name="roleManager">Injected Role Manager</param>
		/// <param name="userManager">Injected User Manager</param>
		/// <returns></returns>
		private static async Task CreateUsers(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			var createdTime = new DateTime(2016,03,01,12,30,00);
			var lastModifiedTime = DateTime.Now;

			const string roleAdministrator = "Administrator";
			const string roleRegisteredUser = "RegisteredUser";

			if (!await roleManager.RoleExistsAsync(roleAdministrator))
				await roleManager.CreateAsync(new IdentityRole(roleAdministrator));

			if (!await roleManager.RoleExistsAsync(roleRegisteredUser))
				await roleManager.CreateAsync(new IdentityRole(roleRegisteredUser));

			var userAdmin = new ApplicationUser()
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = "Admin",
				Email = "kliszczjan@gmail.com",
				CreatedDateTime = createdTime,
				LastModifiedDateTime = lastModifiedTime,
				FirstName = "Admin",
				LastName =  "Admin"
			};

			if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
			{
				await userManager.CreateAsync(userAdmin, "VirtualPharmaRepPassword");
				await userManager.AddToRoleAsync(userAdmin, roleAdministrator);
				await userManager.AddToRoleAsync(userAdmin, roleRegisteredUser);
				userAdmin.EmailConfirmed = true;
				userAdmin.LockoutEnabled = false;
			}

			await dbContext.SaveChangesAsync();
		}

	}
}
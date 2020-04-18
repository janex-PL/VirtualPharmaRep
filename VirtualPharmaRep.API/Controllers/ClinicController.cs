using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Repositories;

namespace VirtualPharmaRep.API.Controllers
{

	[Route("api/[controller]"), ApiController, Authorize]
	public class ClinicController : BaseApiController<Clinic,ClinicRepository,ClinicViewModel>
	{
		#region Constructor

		public ClinicController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
			IConfiguration configuration, ClinicRepository repository) : base(roleManager, userManager, configuration,
			repository)
		{
		}

		#endregion

	}
}
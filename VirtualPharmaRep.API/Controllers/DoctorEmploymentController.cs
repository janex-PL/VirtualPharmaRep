using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Repositories;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/[controller]"), ApiController, Authorize]
	public class DoctorEmploymentController : BaseApiController<DoctorEmployment,DoctorEmploymentRepository,DoctorEmploymentViewModel>
    {
	    public DoctorEmploymentController(RoleManager<IdentityRole> roleManager,
	        UserManager<ApplicationUser> userManager, IConfiguration configuration,
	        DoctorEmploymentRepository repository) : base(roleManager, userManager, configuration, repository)
        {
        }

	    public override async Task<EntityValidationResult> PerformValidationChecks(DoctorEmployment entity)
	    {
		    if (!await Repository.IsForeignKeyValid<Doctor>(entity.DoctorId))
			    return new EntityValidationResult(false, $"Couldn't find Doctor with id: {entity.DoctorId}");

		    if (!await Repository.IsForeignKeyValid<Clinic>(entity.ClinicId))
			    return new EntityValidationResult(false, $"Couldn't find Clinic with id: {entity.ClinicId}");

		    return  new EntityValidationResult(true, string.Empty);
	    }

	    [HttpGet("ByDoctor/{doctorId}")]
	    public async Task<IActionResult> GetByDoctor(int doctorId)
	    {
		    var results = await Repository.GetByDoctor(doctorId);

			return new JsonResult(results.Adapt<List<DoctorEmploymentViewModel>>(), JsonSerializerOptions);
	    }
	    [HttpGet("ByClinic/{clinicId}")]
	    public async Task<IActionResult> GetByClinic(int clinicId)
	    {
		    var results = await Repository.GetByDoctor(clinicId);

		    return new JsonResult(results.Adapt<List<DoctorEmploymentViewModel>>(), JsonSerializerOptions);
	    }
	}
}
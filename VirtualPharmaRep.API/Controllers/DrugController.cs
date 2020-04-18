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
	public class DrugController : BaseApiController<Drug,DrugRepository,DrugViewModel>
    {
	    public DrugController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration, DrugRepository repository) : base(roleManager, userManager, configuration, repository)
	    {
	    }

	    public override async Task<EntityValidationResult> PerformValidationChecks(Drug entity)
	    {
		    if(!await Repository.IsForeignKeyValid<DrugCategory>(entity.DrugCategoryId))
				return new EntityValidationResult(false, $"Couldn't find Drug Category with id: {entity.DrugCategoryId}");

			return new EntityValidationResult(true, string.Empty);
		}

	    [HttpGet("ByCategory/{categoryId}")]
	    public async Task<IActionResult> GetByCategory(int categoryId)
	    {
		    var results = await Repository.GetByCategory(categoryId);

			return new JsonResult(results.Adapt<List<DrugViewModel>>(),JsonSerializerOptions);
	    }
    }
}

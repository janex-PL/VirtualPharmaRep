﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Repositories;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/[controller]"), ApiController, Authorize]
	public class DrugCategoryController : BaseApiController<DrugCategory,DrugCategoryRepository,DrugCategoryViewModel>
    {
	    public DrugCategoryController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IConfiguration configuration, DrugCategoryRepository repository) : base(roleManager, userManager, configuration, repository)
	    {
	    }
    }
}
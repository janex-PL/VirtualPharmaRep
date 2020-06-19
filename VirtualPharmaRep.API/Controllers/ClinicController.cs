using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.API.BaseControllers;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.EntityValidators;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Controllers
{

	[Route("api/[controller]"), ApiController]
	public class ClinicController : BaseApiCrudController<Clinic, ClinicViewModel, ClinicDto, 
        ClinicEntityValidator, ClinicCrudService>
	{
        public ClinicController(ClinicCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }
    }
}
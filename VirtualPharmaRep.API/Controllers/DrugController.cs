using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.API.BaseControllers;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.EntityValidators;
using VirtualPharmaRep.Extensions;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Controllers
{
    [Route("api/[controller]"), ApiController, Authorize]
    public class DrugController : BaseApiCrudController<Drug, DrugViewModel, DrugDto, DrugEntityValidator,
        DrugCrudService>
    {
        public DrugController(DrugCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }

        [HttpGet("ByCategory/{categoryId}")]
        public async Task<ActionResult<IList<DrugDto>>> GetByCategory(int categoryId,[FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByCategory(categoryId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }
    }
}

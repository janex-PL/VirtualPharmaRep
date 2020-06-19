using System.Collections.Generic;
using System.Threading.Tasks;
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
    [Route("api/[controller]"), ApiController]
    public class VisitController : BaseApiCrudController<Visit, VisitViewModel, VisitDto, VisitEntityValidator,
        VisitCrudService>
    {
        public VisitController(VisitCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }

        [HttpGet("ByEmployment/{employmentId}")]
        public async Task<ActionResult<IList<VisitDto>>> GetByEmployment(int employmentId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByEmployment(employmentId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }

        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<IList<VisitDto>>> GetByClinic(string userId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByUser(userId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }
    }
}

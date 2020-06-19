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
    public class TeamMemberController : BaseApiCrudController<TeamMember, TeamMemberViewModel, TeamMemberDto,
        TeamMemberEntityValidator, TeamMemberCrudService>
    {
        public TeamMemberController(TeamMemberCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }

        [HttpGet("ByTeam/{teamId}")]
        public async Task<ActionResult<IList<TeamMemberDto>>> GetByTeam(int teamId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByTeam(teamId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }
    }
}

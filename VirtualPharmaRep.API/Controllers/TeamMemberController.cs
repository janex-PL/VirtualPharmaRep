﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.API.Attributes;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Extensions;
using VirtualPharmaRep.Services.CrudServices.Interfaces;

namespace VirtualPharmaRep.API.Controllers
{
    [Route("api/teammembers"), ApiController, Authorize]
    public class TeamMemberController : ControllerBase
    {
        #region Services
        private readonly ITeamMemberCrudService _crudService;
        #endregion

        #region Constructor
        public TeamMemberController(ITeamMemberCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMemberDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMemberDto>> Get(int id)
        {
            var result = await _crudService.Get(id);

            return result switch
            {
                null => NotFound(new MessageResponse { Message = "Requested resource could not be found" }),
                _ => result
            };
        }
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<TeamMemberDto>> Post([FromBody] TeamMemberViewModel model)
        {
            var result = await _crudService.Add(model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => Conflict(),
                _ => Created($"api/clinics/{result.Id}", result)
            };
        }
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<ActionResult<TeamMemberDto>> Put([FromRoute] int id, [FromBody] TeamMemberViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TeamMemberDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<TeamMemberDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("byteam/{teamId}")]
        public async Task<ActionResult<IList<TeamMemberDto>>> GetByTeam(int teamId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByTeam(teamId, request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        #endregion
    }
}

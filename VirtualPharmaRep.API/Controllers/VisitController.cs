﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
    [Route("api/visits"), ApiController]
    public class VisitController : ControllerBase
    {
        #region Services
        private readonly IVisitCrudService _crudService;
        #endregion

        #region Constructor
        public VisitController(IVisitCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisitDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VisitDto>> Get(int id)
        {
            var result = await _crudService.Get(id);

            return result switch
            {
                null => NotFound(new MessageResponse { Message = "Requested resource could not be found" }),
                _ => Ok(result)
            };
        }
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<VisitDto>> Post([FromBody] VisitViewModel model)
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
        public async Task<ActionResult<VisitDto>> Put([FromRoute] int id, [FromBody] VisitViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisitDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }
        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<VisitDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("byemployment/{employmentId}")]
        public async Task<ActionResult<IList<VisitDto>>> GetByEmployment(int employmentId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByEmployment(employmentId, request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("byuser/{userId}")]
        public async Task<ActionResult<IList<VisitDto>>> GetByClinic(string userId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByUser(userId, request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        #endregion
    }
}

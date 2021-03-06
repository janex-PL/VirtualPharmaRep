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
    [Route("api/drugs"), ApiController, Authorize]
    public class DrugController : ControllerBase
    {
        #region Services
        private readonly IDrugCrudService _crudService;
        #endregion

        #region Constructor
        public DrugController(IDrugCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrugDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DrugDto>> Get(int id)
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
        public async Task<ActionResult<DrugDto>> Post([FromBody] DrugViewModel model)
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
        public async Task<ActionResult<DrugDto>> Put([FromRoute] int id, [FromBody] DrugViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DrugDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<DrugDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("bycategory/{categoryId}")]
        public async Task<ActionResult<IList<DrugDto>>> GetByCategory(int categoryId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByCategory(categoryId, request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        #endregion
    }
}

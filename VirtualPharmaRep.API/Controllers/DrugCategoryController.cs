using System.Collections.Generic;
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
	[Route("api/drugcategories"), ApiController, Authorize]
	public class DrugCategoryController : ControllerBase
    {
        #region Services
        private readonly IDrugCategoryCrudService _crudService;
        #endregion

        #region Constructor
        public DrugCategoryController(IDrugCategoryCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrugCategoryDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DrugCategoryDto>> Get(int id)
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
        public async Task<ActionResult<DrugCategoryDto>> Post([FromBody] DrugCategoryViewModel model)
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
        public async Task<ActionResult<DrugCategoryDto>> Put([FromRoute] int id, [FromBody] DrugCategoryViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DrugCategoryDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }

        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<DrugCategoryDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        #endregion
    }
}

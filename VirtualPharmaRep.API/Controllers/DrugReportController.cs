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
    [Route("api/drugreports"), ApiController, Authorize]
    public class DrugReportController : ControllerBase
    {
        #region Services
        private readonly IDrugReportCrudService _crudService;
        #endregion

        #region Constructor
        public DrugReportController(IDrugReportCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrugReportDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DrugReportDto>> Get(int id)
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
        public async Task<ActionResult<DrugReportDto>> Post([FromBody] DrugReportViewModel model)
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
        public async Task<ActionResult<DrugReportDto>> Put([FromRoute] int id, [FromBody] DrugReportViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DrugReportDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => result
            };
        }
        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<DrugReportDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        [HttpGet("byvisit/{visitId}")]
        public async Task<ActionResult<IList<DrugReportDto>>> GetByVisit(int visitId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByVisit(visitId, request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }

        [HttpGet("bydrug/{drugId}")]
        public async Task<ActionResult<IList<DrugReportDto>>> GetByDrug(int drugId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByDrug(drugId, request);

            Response?.Headers.AddPaginationHeaders(response);

            return response.Result;
        }
        #endregion
    }
}

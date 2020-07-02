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
    [Route("api/doctoremployments"), ApiController, Authorize]
    public class DoctorEmploymentController : ControllerBase
    {
        #region Services
        private readonly IDoctorEmploymentCrudService _crudService;
        #endregion

        #region Constructor
        public DoctorEmploymentController(IDoctorEmploymentCrudService crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorEmploymentDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await _crudService.Get(request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorEmploymentDto>> Get(int id)
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
        public async Task<ActionResult<DoctorEmploymentDto>> Post([FromBody] DoctorEmploymentViewModel model)
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
        public async Task<ActionResult<DoctorEmploymentDto>> Put([FromRoute] int id, [FromBody] DoctorEmploymentViewModel model)
        {
            var result = await _crudService.Edit(id, model, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoctorEmploymentDto>> Delete([FromRoute] int id)
        {
            var result = await _crudService.Delete(id, User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }
        [HttpGet("trash")]
        public async Task<ActionResult<IEnumerable<DoctorEmploymentDto>>> GetTrash([FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetTrash(request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("bydoctor/{doctorId}")]
        public async Task<ActionResult<IList<DoctorEmploymentDto>>> GetByDoctor([FromRoute] int doctorId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByDoctor(doctorId, request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        [HttpGet("byclinic/{clinicId}")]
        public async Task<ActionResult<IList<DoctorEmploymentDto>>> GetByClinic([FromRoute] int clinicId, [FromQuery] PagedRequest request)
        {
            var response = await _crudService.GetByClinic(clinicId, request);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }
        #endregion
    }
}
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
    public class DoctorEmploymentController : BaseApiCrudController<DoctorEmployment, DoctorEmploymentViewModel,
        DoctorEmploymentDto, DoctorEmploymentEntityValidator, DoctorEmploymentCrudService>
    {
        public DoctorEmploymentController(DoctorEmploymentCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }

        [HttpGet("ByDoctor/{doctorId}")]
        public async Task<ActionResult<IList<DoctorEmploymentDto>>> GetByDoctor(int doctorId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByDoctor(doctorId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }

        [HttpGet("ByClinic/{clinicId}")]
        public async Task<ActionResult<IList<DoctorEmploymentDto>>> GetByClinic(int clinicId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByClinic(clinicId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }
    }
}
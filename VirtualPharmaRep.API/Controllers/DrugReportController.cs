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
    public class DrugReportController : BaseApiCrudController<DrugReport, DrugReportViewModel, DrugReportDto,
        DrugReportEntityValidator, DrugReportCrudService>
    {
        public DrugReportController(DrugReportCrudService crudService, IPermissionResolverService permissionResolverService) : base(crudService, permissionResolverService)
        {
        }

        [HttpGet("ByVisit/{visitId}")]
        public async Task<ActionResult<IList<DrugReportDto>>> GetByVisit(int visitId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByVisit(visitId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }

        [HttpGet("ByDrug/{drugId}")]
        public async Task<ActionResult<IList<DrugReportDto>>> GetByDrug(int drugId, [FromQuery] PagedRequest request)
        {
            var response = await CrudService.GetByDrug(drugId, request);
            Response.Headers.AddPaginationHeaders(response);
            return Ok(response.Result);
        }
    }
}

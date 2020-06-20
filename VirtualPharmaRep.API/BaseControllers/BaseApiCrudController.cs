using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.API.Attributes;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels.Interfaces;
using VirtualPharmaRep.Database.EntityValidators.Interfaces;
using VirtualPharmaRep.Extensions;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.BaseControllers
{
    /// <summary>
    /// Base API CRUD Controller
    /// </summary>
    public abstract class BaseApiCrudController<TEntity, TViewModel, TDto, TValidator, TService> : ControllerBase
        where TEntity : class, IEntity
        where TViewModel : class, IViewModel
        where TDto : class, IDto
        where TValidator : class, IEntityValidator<TEntity>
        where TService : BaseCrudService<TEntity, TViewModel, TDto, TValidator>
    {
        #region Properties

        protected readonly TService CrudService;
        protected readonly IPermissionResolverService PermissionResolverService;
        protected readonly PermissionResolverResult PermissionResolverResult;

        #endregion

        #region Constructor
        protected BaseApiCrudController(TService crudService, IPermissionResolverService permissionResolverService)
        {
            CrudService = crudService;
            PermissionResolverService = permissionResolverService;
            PermissionResolverResult = new PermissionResolverResult { AccessLevel = AccessLevel.Global, SendRequest = SendRequest.All, UserId = "xd" };
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<IList<TDto>>> Get([FromQuery] PagedRequest request)
        {
            var response = await CrudService.Get(request, PermissionResolverResult);

            Response.Headers.AddPaginationHeaders(response);

            return Ok(response.Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            var result = await CrudService.Get(id, PermissionResolverResult);

            return result switch
            {
                null => NotFound(new MessageResponse { Message = "Requested resource could not be found or access to it has been denied" }),
                _ => Ok(result)
            };
        }

        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<TDto>> Post([FromBody] TViewModel model)
        {
            var result = await CrudService.Add(model, PermissionResolverResult);
            return result switch
            {
                null => Conflict(),
                _ => Created($"api/{typeof(TEntity).Name}/{result.Id}", result)
            };
        }

        [HttpPatch("{id}")]
        [ValidateModel]
        public async Task<ActionResult<TDto>> Put([FromRoute] int id, [FromBody] TViewModel model)
        {
            var result = await CrudService.Edit(id, model, PermissionResolverResult);
            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TDto>> Delete(int id)
        {
            var result = await CrudService.Delete(id, PermissionResolverResult);

            return result switch
            {
                null => NotFound(),
                _ => Ok(result)
            };
        }

        #endregion
    }
}
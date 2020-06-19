using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IBaseCrudService<TDto, TViewModel> where TDto : class, IDto
    where TViewModel : class, IViewModel
    {
        Task<PagedListResponse<TDto>> Get(PagedRequest request,PermissionResolverResult permissionResult);
        Task<TDto> Get(int id, PermissionResolverResult permissionResult);
        Task<TDto> Add(TViewModel entity, PermissionResolverResult permissionResult);
        Task<List<TDto>> AddRange(IList<TViewModel> models, PermissionResolverResult permissionResult);
        Task<TDto> Edit(int id, TViewModel entity, PermissionResolverResult permissionResult);
        Task<TDto> Delete(int id, PermissionResolverResult permissionResult);
    }
}

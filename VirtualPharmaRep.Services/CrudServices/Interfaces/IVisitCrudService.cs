using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IVisitCrudService
    {
        public Task<PagedListResponse<VisitDto>> Get(PagedRequest request);
        public Task<VisitDto> Get(int id);
        public Task<VisitDto> Add(VisitViewModel model, string requestAuthor);
        public Task<VisitDto> Edit(int id, VisitViewModel model, string requestAuthor);
        public Task<VisitDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<VisitDto>> GetByEmployment(int employmentId, PagedRequest request);
        public Task<PagedListResponse<VisitDto>> GetByUser(string userId, PagedRequest request);
        public Task<PagedListResponse<VisitDto>> GetTrash(PagedRequest request);
    }
}
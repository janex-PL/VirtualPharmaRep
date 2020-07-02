using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDrugCrudService
    {
        public Task<PagedListResponse<DrugDto>> Get(PagedRequest request);
        public Task<DrugDto> Get(int id);
        public Task<DrugDto> Add(DrugViewModel model, string requestAuthor);
        public Task<DrugDto> Edit(int id, DrugViewModel model, string requestAuthor);
        public Task<DrugDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DrugDto>> GetByCategory(int categoryId, PagedRequest request);
        public Task<PagedListResponse<DrugDto>> GetTrash(PagedRequest request);
    }
}
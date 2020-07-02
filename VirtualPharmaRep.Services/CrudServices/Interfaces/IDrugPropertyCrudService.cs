using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDrugPropertyCrudService
    {
        public Task<PagedListResponse<DrugPropertyDto>> Get(PagedRequest request);
        public Task<DrugPropertyDto> Get(int id);
        public Task<DrugPropertyDto> Add(DrugPropertyViewModel model, string requestAuthor);
        public Task<DrugPropertyDto> Edit(int id, DrugPropertyViewModel model, string requestAuthor);
        public Task<DrugPropertyDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DrugPropertyDto>> GetByDrug(int drugId, PagedRequest request);
        public Task<PagedListResponse<DrugPropertyDto>> GetTrash(PagedRequest request);
    }
}
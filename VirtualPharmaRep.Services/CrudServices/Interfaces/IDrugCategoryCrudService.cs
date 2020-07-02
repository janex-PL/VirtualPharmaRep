using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDrugCategoryCrudService
    {
        public Task<PagedListResponse<DrugCategoryDto>> Get(PagedRequest request);
        public Task<DrugCategoryDto> Get(int id);
        public Task<DrugCategoryDto> Add(DrugCategoryViewModel model, string requestAuthor);
        public Task<DrugCategoryDto> Edit(int id, DrugCategoryViewModel model, string requestAuthor);
        public Task<DrugCategoryDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DrugCategoryDto>> GetTrash(PagedRequest request);
    }
}
using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDrugReportCrudService
    {
        public Task<PagedListResponse<DrugReportDto>> Get(PagedRequest request);
        public Task<DrugReportDto> Get(int id);
        public Task<DrugReportDto> Add(DrugReportViewModel model, string requestAuthor);
        public Task<DrugReportDto> Edit(int id, DrugReportViewModel model, string requestAuthor);
        public Task<DrugReportDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DrugReportDto>> GetByVisit(int visitId, PagedRequest request);
        public Task<PagedListResponse<DrugReportDto>> GetByDrug(int drugId, PagedRequest request);
        public Task<PagedListResponse<DrugReportDto>> GetTrash(PagedRequest request);
    }
}
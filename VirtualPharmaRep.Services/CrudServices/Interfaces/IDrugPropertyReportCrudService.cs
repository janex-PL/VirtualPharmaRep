using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDrugPropertyReportCrudService
    {
        public Task<PagedListResponse<DrugPropertyReportDto>> Get(PagedRequest request);
        public Task<DrugPropertyReportDto> Get(int id);
        public Task<DrugPropertyReportDto> Add(DrugPropertyReportViewModel model, string requestAuthor);
        public Task<DrugPropertyReportDto> Edit(int id, DrugPropertyReportViewModel model, string requestAuthor);
        public Task<DrugPropertyReportDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DrugPropertyReportDto>> GetByDrugReport(int drugReportId, PagedRequest request);
        public Task<PagedListResponse<DrugPropertyReportDto>> GetByProperty(int propertyId, PagedRequest request);
        public Task<PagedListResponse<DrugPropertyReportDto>> GetTrash(PagedRequest request);
    }
}
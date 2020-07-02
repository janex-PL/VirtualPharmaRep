using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IClinicCrudService
    {
        public Task<PagedListResponse<ClinicDto>> Get(PagedRequest request);
        public Task<ClinicDto> Get(int id);
        public Task<ClinicDto> Add(ClinicViewModel model, string requestAuthor);
        public Task<ClinicDto> Edit(int id, ClinicViewModel model, string requestAuthor);
        public Task<ClinicDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<ClinicDto>> GetTrash(PagedRequest request);
    }
}

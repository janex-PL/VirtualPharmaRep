using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDoctorCrudService
    {
        public Task<PagedListResponse<DoctorDto>> Get(PagedRequest request);
        public Task<DoctorDto> Get(int id);
        public Task<DoctorDto> Add(DoctorViewModel model, string requestAuthor);
        public Task<DoctorDto> Edit(int id, DoctorViewModel model, string requestAuthor);
        public Task<DoctorDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DoctorDto>> GetTrash(PagedRequest request);
    }
}

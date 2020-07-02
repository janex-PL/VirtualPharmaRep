using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface IDoctorEmploymentCrudService
    {
        public Task<PagedListResponse<DoctorEmploymentDto>> Get(PagedRequest request);
        public Task<DoctorEmploymentDto> Get(int id);
        public Task<DoctorEmploymentDto> Add(DoctorEmploymentViewModel model, string requestAuthor);
        public Task<DoctorEmploymentDto> Edit(int id, DoctorEmploymentViewModel model, string requestAuthor);
        public Task<DoctorEmploymentDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<DoctorEmploymentDto>> GetByDoctor(int doctorId, PagedRequest request);
        public Task<PagedListResponse<DoctorEmploymentDto>> GetByClinic(int clinicId, PagedRequest request);
        public Task<PagedListResponse<DoctorEmploymentDto>> GetTrash(PagedRequest request);
    }
}

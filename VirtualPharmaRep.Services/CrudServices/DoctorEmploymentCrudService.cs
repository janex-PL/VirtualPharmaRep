using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class DoctorEmploymentCrudService : BaseCrudService<DoctorEmployment, DoctorEmploymentViewModel,
        DoctorEmploymentDto, DoctorEmploymentEntityValidator>
    {
        public DoctorEmploymentCrudService(DoctorEmploymentEntityValidator validator, IMapper mapper,
            ApplicationDbContext context) : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<DoctorEmploymentDto>> GetByDoctor(int doctorId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(new PagedListResponse<DoctorEmployment>(
                await Context.Set<DoctorEmployment>().Where(de => de.DoctorId == doctorId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }

        public async Task<PagedListResponse<DoctorEmploymentDto>> GetByClinic(int clinicId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(new PagedListResponse<DoctorEmployment>(
                await Context.Set<DoctorEmployment>().Where(de => de.ClinicId == clinicId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Services.CrudServices.Interfaces;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class DoctorEmploymentCrudService : BaseCrudService, IDoctorEmploymentCrudService
    {
        #region Constructor
        public DoctorEmploymentCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DoctorEmploymentDto>> Get(PagedRequest request)
        {
            var resultList = await Context.DoctorEmployments.AsNoTracking().Include(de => de.Doctor)
                .Include(de => de.Clinic).ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(
                new PagedListResponse<DoctorEmployment>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DoctorEmploymentDto> Get(int id)
        {
            var result = await Context.DoctorEmployments.AsNoTracking().Include(de => de.Doctor)
                .Include(de => de.Clinic).FirstOrDefaultAsync(de => de.Id == id);

            return Mapper.Map<DoctorEmploymentDto>(result);
        }
        public async Task<DoctorEmploymentDto> Add(DoctorEmploymentViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DoctorEmployment>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DoctorEmploymentDto>(result.Entity);
        }
        public async Task<DoctorEmploymentDto> Edit(int id, DoctorEmploymentViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DoctorEmployment>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DoctorEmploymentDto>(entity);
        }
        public async Task<DoctorEmploymentDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.DoctorEmployments.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DoctorEmploymentDto>(result.Entity);
        }
        public async Task<PagedListResponse<DoctorEmploymentDto>> GetByDoctor(int doctorId, PagedRequest request)
        {
            var resultList = await Context.DoctorEmployments.AsNoTracking().Where(de => de.DoctorId == doctorId)
                .Include(de => de.Doctor).Include(de => de.Clinic).ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(
                new PagedListResponse<DoctorEmployment>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DoctorEmploymentDto>> GetByClinic(int clinicId, PagedRequest request)
        {
            var resultList = await Context.DoctorEmployments.AsNoTracking().Where(de => de.ClinicId == clinicId)
                .Include(de => de.Doctor).Include(de => de.Clinic).ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(
                new PagedListResponse<DoctorEmployment>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DoctorEmploymentDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.DoctorEmployments.AsNoTracking().IgnoreQueryFilters()
                .Where(de => de.IsDeleted).Include(de => de.Doctor).Include(de => de.Clinic).ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorEmploymentDto>>(
                new PagedListResponse<DoctorEmployment>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
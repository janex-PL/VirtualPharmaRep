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
    public class VisitCrudService : BaseCrudService, IVisitCrudService
    {
        #region Constructor
        public VisitCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<VisitDto>> Get(PagedRequest request)
        {
            var resultList = await Context.Visits.AsNoTracking().Include(v => v.User).Include(v => v.DoctorEmployment)
                .ThenInclude(de => de.Clinic).Include(v => v.DoctorEmployment).ThenInclude(de => de.Doctor)
                .Include(v => v.DrugReports).ToListAsync();

            return Mapper.Map<PagedListResponse<VisitDto>>(
                new PagedListResponse<Visit>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<VisitDto> Get(int id)
        {
            var result = await Context.Visits.AsNoTracking().Include(v => v.User).Include(v => v.DoctorEmployment)
                .ThenInclude(de => de.Clinic).Include(v => v.DoctorEmployment).ThenInclude(de => de.Doctor)
                .Include(v => v.DrugReports).FirstOrDefaultAsync(v => v.Id == id);

            return Mapper.Map<VisitDto>(result);
        }
        public async Task<VisitDto> Add(VisitViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Visit>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<VisitDto>(result.Entity);
        }
        public async Task<VisitDto> Edit(int id, VisitViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Visit>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<VisitDto>(entity);
        }
        public async Task<VisitDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.Visits.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<VisitDto>(result.Entity);
        }
        public async Task<PagedListResponse<VisitDto>> GetByEmployment(int employmentId, PagedRequest request)
        {
            var resultList = await Context.Visits.AsNoTracking().Include(v => v.User).Include(v => v.DoctorEmployment)
                .ThenInclude(de => de.Clinic).Include(v => v.DoctorEmployment).ThenInclude(de => de.Doctor)
                .Include(v => v.DrugReports).Where(v => v.DoctorEmploymentId == employmentId).ToListAsync();

            return Mapper.Map<PagedListResponse<VisitDto>>(new PagedListResponse<Visit>(resultList, request.PageSize,
                request.PageNumber));
        }
        public async Task<PagedListResponse<VisitDto>> GetByUser(string userId, PagedRequest request)
        {
            var resultList = await Context.Visits.AsNoTracking().Include(v => v.User).Include(v => v.DoctorEmployment)
                .ThenInclude(de => de.Clinic).Include(v => v.DoctorEmployment).ThenInclude(de => de.Doctor)
                .Include(v => v.DrugReports).Where(v => v.UserId == userId).ToListAsync();

            return Mapper.Map<PagedListResponse<VisitDto>>(new PagedListResponse<Visit>(resultList, request.PageSize,
                request.PageNumber));
        }
        public async Task<PagedListResponse<VisitDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.Visits.IgnoreQueryFilters().AsNoTracking().Where(v => v.IsDeleted).Include(v => v.User).Include(v => v.DoctorEmployment)
                .ThenInclude(de => de.Clinic).Include(v => v.DoctorEmployment).ThenInclude(de => de.Doctor)
                .Include(v => v.DrugReports).ToListAsync();

            return Mapper.Map<PagedListResponse<VisitDto>>(
                new PagedListResponse<Visit>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
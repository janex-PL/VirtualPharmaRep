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
    public class DoctorCrudService : BaseCrudService, IDoctorCrudService
    {
        #region Constructor
        public DoctorCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DoctorDto>> Get(PagedRequest request)
        {
            var resultList = await Context.Doctors.Include(d => d.DoctorEmployments).ThenInclude(de => de.Clinic)
                .AsNoTracking().ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorDto>>(
                new PagedListResponse<Doctor>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DoctorDto> Get(int id)
        {
            var result = await Context.Doctors.Include(d => d.DoctorEmployments).ThenInclude(de => de.Clinic)
                .AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);

            return Mapper.Map<DoctorDto>(result);
        }
        public async Task<DoctorDto> Add(DoctorViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Doctor>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DoctorDto>(result.Entity);
        }
        public async Task<DoctorDto> Edit(int id, DoctorViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Doctor>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DoctorDto>(entity);
        }
        public async Task<DoctorDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.Doctors.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DoctorDto>(result.Entity);
        }
        public async Task<PagedListResponse<DoctorDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.Doctors.IgnoreQueryFilters().Where(d => d.IsDeleted).Include(d => d.DoctorEmployments).ThenInclude(de => de.Clinic)
                .AsNoTracking().ToListAsync();

            return Mapper.Map<PagedListResponse<DoctorDto>>(
                new PagedListResponse<Doctor>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
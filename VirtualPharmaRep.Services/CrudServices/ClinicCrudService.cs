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
    public class ClinicCrudService : BaseCrudService, IClinicCrudService
    {
        #region Constructor
        public ClinicCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<ClinicDto>> Get(PagedRequest request)
        {
            var resultList = await Context.Clinics.Include(c => c.DoctorEmployments).ThenInclude(de => de.Doctor).ToListAsync();

            return Mapper.Map<PagedListResponse<ClinicDto>>(
                new PagedListResponse<Clinic>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<ClinicDto> Get(int id)
        {
            var result = await Context.Clinics.Include(c => c.DoctorEmployments).ThenInclude(de => de.Doctor).FirstOrDefaultAsync(c => c.Id == id);

            return Mapper.Map<ClinicDto>(result);
        }
        public async Task<ClinicDto> Add(ClinicViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Clinic>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.Clinics.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<ClinicDto>(result.Entity);
        }
        public async Task<ClinicDto> Edit(int id, ClinicViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Clinic>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<ClinicDto>(entity);
        }
        public async Task<ClinicDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.Clinics.FirstOrDefaultAsync(c => c.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<ClinicDto>(result.Entity);
        }
        public async Task<PagedListResponse<ClinicDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.Clinics.IgnoreQueryFilters().Where(c => c.IsDeleted)
                .Include(c => c.DoctorEmployments).ThenInclude(de => de.Doctor).ToListAsync();

            return Mapper.Map<PagedListResponse<ClinicDto>>(
                new PagedListResponse<Clinic>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}

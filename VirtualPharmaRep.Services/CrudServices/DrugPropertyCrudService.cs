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
    public class DrugPropertyCrudService : BaseCrudService, IDrugPropertyCrudService
    {
        #region Constructor
        public DrugPropertyCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DrugPropertyDto>> Get(PagedRequest request)
        {
            var resultList = await Context.DrugProperties.AsNoTracking().Include(dp => dp.Drug)
                .Include(dp => dp.DrugPropertyReports).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyDto>>(
                new PagedListResponse<DrugProperty>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DrugPropertyDto> Get(int id)
        {
            var result = await Context.DrugProperties.AsNoTracking().Include(dp => dp.Drug)
                .Include(dp => dp.DrugPropertyReports).FirstOrDefaultAsync(d => d.Id == id);

            return Mapper.Map<DrugPropertyDto>(result);
        }
        public async Task<DrugPropertyDto> Add(DrugPropertyViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugProperty>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DrugPropertyDto>(result.Entity);
        }
        public async Task<DrugPropertyDto> Edit(int id, DrugPropertyViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugProperty>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugPropertyDto>(entity);
        }
        public async Task<DrugPropertyDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.DrugProperties.AsNoTracking().FirstOrDefaultAsync(dc => dc.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugPropertyDto>(result.Entity);
        }
        public async Task<PagedListResponse<DrugPropertyDto>> GetByDrug(int drugId, PagedRequest request)
        {
            var resultList = await Context.DrugProperties.AsNoTracking().Include(dp => dp.Drug)
                .Include(dp => dp.DrugPropertyReports).Where(dp => dp.DrugId == drugId).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyDto>>(new PagedListResponse<DrugProperty>(resultList,
                request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DrugPropertyDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.DrugProperties.AsNoTracking().IgnoreQueryFilters().Where(dp => dp.IsDeleted)
                .Include(dp => dp.Drug).Include(dp => dp.DrugPropertyReports).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyDto>>(new PagedListResponse<DrugProperty>(resultList,
                request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
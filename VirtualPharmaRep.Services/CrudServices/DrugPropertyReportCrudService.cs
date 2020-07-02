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
    public class DrugPropertyReportCrudService : BaseCrudService, IDrugPropertyReportCrudService
    {
        #region Constructor
        public DrugPropertyReportCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DrugPropertyReportDto>> Get(PagedRequest request)
        {
            var resultList = await Context.DrugPropertyReports.AsNoTracking().Include(dpr => dpr.DrugProperty)
                .ThenInclude(dp => dp.Drug).Include(dpr => dpr.DrugReport).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(
                new PagedListResponse<DrugPropertyReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DrugPropertyReportDto> Get(int id)
        {
            var result = await Context.DrugPropertyReports.AsNoTracking().Include(dpr => dpr.DrugProperty)
                .ThenInclude(dp => dp.Drug).Include(dpr => dpr.DrugReport).FirstOrDefaultAsync(dpr => dpr.Id == id);

            return Mapper.Map<DrugPropertyReportDto>(result);
        }
        public async Task<DrugPropertyReportDto> Add(DrugPropertyReportViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugPropertyReport>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DrugPropertyReportDto>(result.Entity);
        }
        public async Task<DrugPropertyReportDto> Edit(int id, DrugPropertyReportViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugPropertyReport>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugPropertyReportDto>(entity);
        }
        public async Task<DrugPropertyReportDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.DrugPropertyReports.AsNoTracking().FirstOrDefaultAsync(dpr => dpr.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugPropertyReportDto>(result.Entity);
        }
        public async Task<PagedListResponse<DrugPropertyReportDto>> GetByDrugReport(int drugReportId, PagedRequest request)
        {
            var resultList = await Context.DrugPropertyReports.Where(dpr => dpr.DrugReportId == drugReportId)
                .AsNoTracking().Include(dpr => dpr.DrugProperty).Include(dpr => dpr.DrugReport).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(
                new PagedListResponse<DrugPropertyReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DrugPropertyReportDto>> GetByProperty(int propertyId, PagedRequest request)
        {
            var resultList = await Context.DrugPropertyReports.Where(dpr => dpr.DrugPropertyId == propertyId)
                .AsNoTracking().Include(dpr => dpr.DrugProperty).Include(dpr => dpr.DrugReport).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(
                new PagedListResponse<DrugPropertyReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DrugPropertyReportDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.DrugPropertyReports.IgnoreQueryFilters().Where(dpr => dpr.IsDeleted)
                .AsNoTracking().Include(dpr => dpr.DrugProperty).Include(dpr => dpr.DrugReport).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(
                new PagedListResponse<DrugPropertyReport>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}

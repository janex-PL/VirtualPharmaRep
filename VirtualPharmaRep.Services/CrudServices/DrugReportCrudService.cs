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
    public class DrugReportCrudService : BaseCrudService, IDrugReportCrudService
    {
        #region Constructor
        public DrugReportCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DrugReportDto>> Get(PagedRequest request)
        {
            var resultList = await Context.DrugReports.AsNoTracking().Include(dr => dr.Drug)
                .Include(dr => dr.DrugPropertyReports).Include(dr => dr.Visit).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugReportDto>>(
                new PagedListResponse<DrugReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DrugReportDto> Get(int id)
        {
            var result = await Context.DrugReports.AsNoTracking().Include(dr => dr.Drug)
                .Include(dr => dr.DrugPropertyReports).Include(dr => dr.Visit).FirstOrDefaultAsync(dr => dr.Id == id);

            return Mapper.Map<DrugReportDto>(result);
        }
        public async Task<DrugReportDto> Add(DrugReportViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugReport>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DrugReportDto>(result.Entity);
        }
        public async Task<DrugReportDto> Edit(int id, DrugReportViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugReport>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugReportDto>(entity);
        }
        public async Task<DrugReportDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.DrugReports.AsNoTracking().FirstOrDefaultAsync(dr => dr.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugReportDto>(result.Entity);
        }
        public async Task<PagedListResponse<DrugReportDto>> GetByVisit(int visitId, PagedRequest request)
        {
            var resultList = await Context.DrugReports.AsNoTracking().Include(dr => dr.Drug)
                .Include(dr => dr.DrugPropertyReports).Include(dr => dr.Visit).Where(dr => dr.VisitId == visitId).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugReportDto>>(
                new PagedListResponse<DrugReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DrugReportDto>> GetByDrug(int drugId, PagedRequest request)
        {
            var resultList = await Context.DrugReports.AsNoTracking().Include(dr => dr.Drug)
                .Include(dr => dr.DrugPropertyReports).Include(dr => dr.Visit).Where(dr => dr.DrugId == drugId).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugReportDto>>(
                new PagedListResponse<DrugReport>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<DrugReportDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.DrugReports.AsNoTracking().Include(dr => dr.Drug)
                .Include(dr => dr.DrugPropertyReports).Include(dr => dr.Visit).IgnoreQueryFilters()
                .Where(dr => dr.IsDeleted).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugReportDto>>(
                new PagedListResponse<DrugReport>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}

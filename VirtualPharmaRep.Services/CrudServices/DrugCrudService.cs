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
    public class DrugCrudService : BaseCrudService, IDrugCrudService
    {
        #region Constructor
        public DrugCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DrugDto>> Get(PagedRequest request)
        {
            var resultList = await Context.Drugs

                .Include(d => d.DrugCategory).Include(d => d.DrugProperties).Include(d => d.DrugReports).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugDto>>(new PagedListResponse<Drug>(resultList, request.PageSize,
                request.PageNumber));
        }
        public async Task<DrugDto> Get(int id)
        {
            var result = await Context.Drugs.Include(d => d.DrugCategory).Include(d => d.DrugProperties)
                .Include(d => d.DrugReports).FirstOrDefaultAsync(d => d.Id == id);

            return Mapper.Map<DrugDto>(result);
        }
        public async Task<DrugDto> Add(DrugViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Drug>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DrugDto>(result.Entity);
        }
        public async Task<DrugDto> Edit(int id, DrugViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Drug>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugDto>(entity);
        }
        public async Task<DrugDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.Drugs.FirstOrDefaultAsync(dc => dc.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugDto>(result.Entity);
        }
        public async Task<PagedListResponse<DrugDto>> GetByCategory(int categoryId, PagedRequest request)
        {
            var resultList = await Context.Drugs.Where(d => d.DrugCategoryId == categoryId)
                .Include(d => d.DrugCategory).Include(d => d.DrugProperties).Include(d => d.DrugReports).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugDto>>(new PagedListResponse<Drug>(resultList, request.PageSize,
                request.PageNumber));
        }
        public async Task<PagedListResponse<DrugDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.Drugs.IgnoreQueryFilters().Where(d => d.IsDeleted)
                .Include(d => d.DrugCategory).Include(d => d.DrugProperties).Include(d => d.DrugReports).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugDto>>(new PagedListResponse<Drug>(resultList, request.PageSize,
                request.PageNumber));
        }
        #endregion
    }
}
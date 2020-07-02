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
    public class DrugCategoryCrudService : BaseCrudService, IDrugCategoryCrudService
    {
        #region Constructor
        public DrugCategoryCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<DrugCategoryDto>> Get(PagedRequest request)
        {
            var resultList = await Context.DrugCategories.AsNoTracking().Include(dc => dc.Drugs).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugCategoryDto>>(
                new PagedListResponse<DrugCategory>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<DrugCategoryDto> Get(int id)
        {
            var result = await Context.DrugCategories.AsNoTracking().Include(dc => dc.Drugs)
                .FirstOrDefaultAsync(dc => dc.Id == id);

            return Mapper.Map<DrugCategoryDto>(result);
        }
        public async Task<DrugCategoryDto> Add(DrugCategoryViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugCategory>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<DrugCategoryDto>(result.Entity);
        }
        public async Task<DrugCategoryDto> Edit(int id, DrugCategoryViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<DrugCategory>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugCategoryDto>(entity);
        }
        public async Task<DrugCategoryDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.DrugCategories.AsNoTracking().FirstOrDefaultAsync(dc => dc.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<DrugCategoryDto>(result.Entity);
        }
        public async Task<PagedListResponse<DrugCategoryDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.DrugCategories.AsNoTracking().IgnoreQueryFilters().Where(dc => dc.IsDeleted).Include(dc => dc.Drugs).ToListAsync();

            return Mapper.Map<PagedListResponse<DrugCategoryDto>>(
                new PagedListResponse<DrugCategory>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
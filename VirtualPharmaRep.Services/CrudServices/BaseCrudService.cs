using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.CustomObjects;
using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Entities.Interfaces;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels.Interfaces;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators.Interfaces;
using VirtualPharmaRep.Services.CrudServices.Interfaces;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class BaseCrudService<TEntity, TViewModel, TDto, TValidator> : IBaseCrudService<TDto, TViewModel>
        where TEntity : class, IEntity
        where TViewModel : class, IViewModel
        where TDto : class, IDto
        where TValidator : IEntityValidator<TEntity>
    {
        protected readonly ApplicationDbContext Context;
        protected readonly TValidator Validator;
        protected readonly IMapper Mapper;

        public BaseCrudService(TValidator validator, IMapper mapper, ApplicationDbContext context)
        {
            Validator = validator;
            Mapper = mapper;
            Context = context;
        }

        public async Task<PagedListResponse<TDto>> Get(PagedRequest request, PermissionResolverResult permissionResult)
        {
            var resultList = await Context.Set<TEntity>().AsNoTracking().ToListAsync();

            if (permissionResult.AccessLevel == AccessLevel.Private)
                resultList = resultList.Where(e => e.CreatedBy == permissionResult.UserId).ToList();

            return Mapper.Map<PagedListResponse<TDto>>(
                new PagedListResponse<TEntity>(resultList, request.PageSize,
                    request.PageNumber));

        }

        public async Task<TDto> Get(int id, PermissionResolverResult permissionResult)
        {
            var result = await Context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

            if (permissionResult.AccessLevel == AccessLevel.Private && result.CreatedBy != permissionResult.UserId)
                return null;

            return Mapper.Map<TDto>(result);
        }

        public async Task<TDto> Add(TViewModel model, PermissionResolverResult permissionResult)
        {
            var entity = Mapper.Map<TEntity>(model);

            await Validator.PerformValidationChecks(entity, permissionResult);

            entity.CreatedBy = permissionResult.UserId;

            var result = await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<TDto>(result.Entity);
        }

        public async Task<List<TDto>> AddRange(IList<TViewModel> models, PermissionResolverResult permissionResult)
        {
            var entities = Mapper.Map<List<TEntity>>(models);
            foreach (var entity in entities)
            {
               await Validator.PerformValidationChecks(entity, permissionResult);
               entity.CreatedBy = permissionResult.UserId;
            }

            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsyncWithAudit(permissionResult.UserId);

            return Mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> Edit(int id, TViewModel model, PermissionResolverResult permissionResult)
        {
            var entity = Mapper.Map<TEntity>(model);
            entity.Id = id;

            await Validator.PerformValidationChecks(entity, permissionResult);
            
            var result = Context.Update(entity);
            await Context.SaveChangesAsyncWithAudit(permissionResult.UserId);

            return Mapper.Map<TDto>(result.Entity);
        }

        public async Task<TDto> Delete(int id, PermissionResolverResult permissionResult)
        {
            var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity == null)
                return null;

            var result = Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsyncWithAudit(permissionResult.UserId);

            return Mapper.Map<TDto>(result.Entity);
        }
    }
}

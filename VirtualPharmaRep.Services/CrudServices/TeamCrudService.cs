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
    public class TeamCrudService : BaseCrudService, ITeamCrudService
    {
        #region Constructor
        public TeamCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<TeamDto>> Get(PagedRequest request)
        {
            var resultList = await Context.Teams.Include(t => t.TeamMembers).ThenInclude(tm => tm.User)
                .ToListAsync();

            return Mapper.Map<PagedListResponse<TeamDto>>(
                new PagedListResponse<Team>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<TeamDto> Get(int id)
        {
            var result = await Context.Teams.Include(t => t.TeamMembers).ThenInclude(tm => tm.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            return Mapper.Map<TeamDto>(result);
        }
        public async Task<TeamDto> Add(TeamViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Team>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<TeamDto>(result.Entity);
        }
        public async Task<TeamDto> Edit(int id, TeamViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<Team>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<TeamDto>(entity);
        }
        public async Task<TeamDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<TeamDto>(result.Entity);
        }
        public async Task<PagedListResponse<TeamDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.Teams.IgnoreQueryFilters().Where(t => t.IsDeleted).Include(t => t.TeamMembers).ThenInclude(tm => tm.User)
                .ToListAsync();

            return Mapper.Map<PagedListResponse<TeamDto>>(
                new PagedListResponse<Team>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
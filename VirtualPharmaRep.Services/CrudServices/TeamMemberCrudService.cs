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
    public class TeamMemberCrudService : BaseCrudService, ITeamMemberCrudService
    {
        #region Constructor
        public TeamMemberCrudService(IMapper mapper, ApplicationDbContext context) : base(mapper, context)
        {
        }
        #endregion

        #region CRUD methods
        public async Task<PagedListResponse<TeamMemberDto>> Get(PagedRequest request)
        {
            var resultList = await Context.TeamMembers.Include(tm => tm.User).Include(tm => tm.Team)
                .ToListAsync();

            return Mapper.Map<PagedListResponse<TeamMemberDto>>(
                new PagedListResponse<TeamMember>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<TeamMemberDto> Get(int id)
        {
            var result = await Context.TeamMembers.Include(tm => tm.User).Include(tm => tm.Team)
                .FirstOrDefaultAsync(t => t.Id == id);

            return Mapper.Map<TeamMemberDto>(result);
        }
        public async Task<TeamMemberDto> Add(TeamMemberViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<TeamMember>(model);

            entity.CreatedBy = requestAuthor;

            var result = await Context.AddAsync(entity);

            await Context.SaveChangesAsyncWithAudit(entity.CreatedBy);

            return Mapper.Map<TeamMemberDto>(result.Entity);
        }
        public async Task<TeamMemberDto> Edit(int id, TeamMemberViewModel model, string requestAuthor)
        {
            var entity = Mapper.Map<TeamMember>(model);
            entity.Id = id;

            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<TeamMemberDto>(entity);
        }
        public async Task<TeamMemberDto> Delete(int id, string requestAuthor)
        {
            var entity = await Context.TeamMembers.FirstOrDefaultAsync(tm => tm.Id == id);

            if (entity == null)
                return null;

            var result = Context.Remove(entity);
            await Context.SaveChangesAsyncWithAudit(requestAuthor);

            return Mapper.Map<TeamMemberDto>(result.Entity);
        }
        public async Task<PagedListResponse<TeamMemberDto>> GetByTeam(int teamId, PagedRequest request)
        {
            var resultList = await Context.TeamMembers.Include(tm => tm.User).Include(tm => tm.Team)
                .Where(tm => tm.TeamId == teamId).ToListAsync();

            return Mapper.Map<PagedListResponse<TeamMemberDto>>(
                new PagedListResponse<TeamMember>(resultList, request.PageSize, request.PageNumber));
        }
        public async Task<PagedListResponse<TeamMemberDto>> GetTrash(PagedRequest request)
        {
            var resultList = await Context.TeamMembers.IgnoreQueryFilters().Where(tm => tm.IsDeleted).Include(tm => tm.User).Include(tm => tm.Team)
                .ToListAsync();

            return Mapper.Map<PagedListResponse<TeamMemberDto>>(
                new PagedListResponse<TeamMember>(resultList, request.PageSize, request.PageNumber));
        }
        #endregion
    }
}
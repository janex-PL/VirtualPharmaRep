using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class TeamMemberCrudService : BaseCrudService<TeamMember, TeamMemberViewModel, TeamMemberDto, TeamMemberEntityValidator>
    {
        public TeamMemberCrudService(TeamMemberEntityValidator validator, IMapper mapper, ApplicationDbContext context)
            : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<TeamMemberDto>> GetByTeam(int teamId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<TeamMemberDto>>(new PagedListResponse<TeamMember>(
                await Context.Set<TeamMember>().Where(tm => tm.TeamId == teamId).ToListAsync(), request.PageSize,
                request.PageNumber));
        }
    }
}
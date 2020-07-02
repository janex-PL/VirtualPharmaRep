using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface ITeamMemberCrudService
    {
        public Task<PagedListResponse<TeamMemberDto>> Get(PagedRequest request);
        public Task<TeamMemberDto> Get(int id);
        public Task<TeamMemberDto> Add(TeamMemberViewModel model, string requestAuthor);
        public Task<TeamMemberDto> Edit(int id, TeamMemberViewModel model, string requestAuthor);
        public Task<TeamMemberDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<TeamMemberDto>> GetByTeam(int teamId, PagedRequest request);
        public Task<PagedListResponse<TeamMemberDto>> GetTrash(PagedRequest request);
    }
}
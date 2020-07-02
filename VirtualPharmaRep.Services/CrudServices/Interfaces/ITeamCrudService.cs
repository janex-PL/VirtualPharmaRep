using System.Threading.Tasks;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Pagination;
using VirtualPharmaRep.Data.ViewModels;

namespace VirtualPharmaRep.Services.CrudServices.Interfaces
{
    public interface ITeamCrudService
    {
        public Task<PagedListResponse<TeamDto>> Get(PagedRequest request);
        public Task<TeamDto> Get(int id);
        public Task<TeamDto> Add(TeamViewModel model, string requestAuthor);
        public Task<TeamDto> Edit(int id, TeamViewModel model, string requestAuthor);
        public Task<TeamDto> Delete(int id, string requestAuthor);
        public Task<PagedListResponse<TeamDto>> GetTrash(PagedRequest request);
    }
}
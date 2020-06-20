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
    public class VisitCrudService : BaseCrudService<Visit, VisitViewModel, VisitDto, VisitEntityValidator>
    {
        public VisitCrudService(VisitEntityValidator validator, IMapper mapper, ApplicationDbContext context) : base(
            validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<VisitDto>> GetByEmployment(int employmentId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<VisitDto>>(new PagedListResponse<Visit>(
                await Context.Set<Visit>().Where(v => v.DoctorEmploymentId == employmentId).AsNoTracking().ToListAsync(),
                request.PageSize, request.PageNumber));
        }

        public async Task<PagedListResponse<VisitDto>> GetByUser(string userId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<VisitDto>>(new PagedListResponse<Visit>(
                await Context.Set<Visit>().Where(v => v.UserId == userId).AsNoTracking().ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}
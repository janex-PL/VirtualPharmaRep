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
    public class DrugReportCrudService : BaseCrudService<DrugReport, DrugReportViewModel, DrugReportDto,
        DrugReportEntityValidator>
    {
        public DrugReportCrudService(DrugReportEntityValidator validator, IMapper mapper, ApplicationDbContext context)
            : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<DrugReportDto>> GetByVisit(int visitId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugReportDto>>(new PagedListResponse<DrugReport>(
                await Context.Set<DrugReport>().Where(dr => dr.VisitId == visitId).AsNoTracking().ToListAsync(),
                request.PageSize, request.PageNumber));
        }

        public async Task<PagedListResponse<DrugReportDto>> GetByDrug(int drugId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugReportDto>>(new PagedListResponse<DrugReport>(
                await Context.Set<DrugReport>().Where(dr => dr.DrugId == drugId).AsNoTracking().ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}

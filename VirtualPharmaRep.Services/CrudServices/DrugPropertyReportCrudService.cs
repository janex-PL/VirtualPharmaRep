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
    public class DrugPropertyReportCrudService : BaseCrudService<DrugPropertyReport, DrugPropertyReportViewModel,
        DrugPropertyReportDto, DrugPropertyReportEntityValidator>
    {
        public DrugPropertyReportCrudService(DrugPropertyReportEntityValidator validator, IMapper mapper,
            ApplicationDbContext context) : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<DrugPropertyReportDto>> GetByDrugReport(int drugReportId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(new PagedListResponse<DrugPropertyReport>(
                await Context.Set<DrugPropertyReport>().Where(dpr => dpr.DrugReportId == drugReportId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }

        public async Task<PagedListResponse<DrugPropertyReportDto>> GetByProperty(int propertyId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugPropertyReportDto>>(new PagedListResponse<DrugPropertyReport>(
                await Context.Set<DrugPropertyReport>().Where(dpr => dpr.DrugPropertyId == propertyId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}

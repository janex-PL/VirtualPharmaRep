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
    public class DrugPropertyCrudService : BaseCrudService<DrugProperty, DrugPropertyViewModel, DrugPropertyDto,
        DrugPropertyEntityValidator>
    {
        public DrugPropertyCrudService(DrugPropertyEntityValidator validator, IMapper mapper,
            ApplicationDbContext context) : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<DrugPropertyDto>> GetByDrug(int drugId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugPropertyDto>>(new PagedListResponse<DrugProperty>(
                await Context.Set<DrugProperty>().Where(d => d.DrugId== drugId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}
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
    public class DrugCrudService : BaseCrudService<Drug, DrugViewModel, DrugDto, DrugEntityValidator>
    {
        public DrugCrudService(DrugEntityValidator validator, IMapper mapper, ApplicationDbContext context) : base(validator, mapper, context)
        {
        }

        public async Task<PagedListResponse<DrugDto>> GetByCategory(int categoryId, PagedRequest request)
        {
            return Mapper.Map<PagedListResponse<DrugDto>>(new PagedListResponse<Drug>(
                await Context.Set<Drug>().Where(d => d.DrugCategoryId == categoryId).ToListAsync(),
                request.PageSize, request.PageNumber));
        }
    }
}
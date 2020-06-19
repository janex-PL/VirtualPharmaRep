using AutoMapper;
using VirtualPharmaRep.Data.Dtos;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.Services.CrudServices
{
    public class DrugCategoryCrudService : BaseCrudService<DrugCategory, DrugCategoryViewModel, DrugCategoryDto,
        DrugCategoryEntityValidator>
    {
        public DrugCategoryCrudService(DrugCategoryEntityValidator validator, IMapper mapper,
            ApplicationDbContext context) : base(validator, mapper, context)
        {
        }
    }
}
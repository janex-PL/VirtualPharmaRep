using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DrugCategoryEntityValidator : BaseEntityValidator<DrugCategory,ApplicationDbContext>
    {
        public DrugCategoryEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
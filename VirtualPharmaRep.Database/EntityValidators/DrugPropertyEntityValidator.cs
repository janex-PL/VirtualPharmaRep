using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DrugPropertyEntityValidator : BaseEntityValidator<DrugProperty,ApplicationDbContext>
    {
        public DrugPropertyEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
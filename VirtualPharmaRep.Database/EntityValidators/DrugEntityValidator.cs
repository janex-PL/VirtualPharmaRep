using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DrugEntityValidator : BaseEntityValidator<Drug,ApplicationDbContext>
    {
        public DrugEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}

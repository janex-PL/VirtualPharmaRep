using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class VisitEntityValidator : BaseEntityValidator<Visit,ApplicationDbContext>
    {
        public VisitEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
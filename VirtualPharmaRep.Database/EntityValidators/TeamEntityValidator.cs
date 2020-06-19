using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class TeamEntityValidator : BaseEntityValidator<Team,ApplicationDbContext>
    {
        public TeamEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
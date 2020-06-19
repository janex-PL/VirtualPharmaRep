using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class TeamMemberEntityValidator : BaseEntityValidator<TeamMember, ApplicationDbContext>
    {
        public TeamMemberEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
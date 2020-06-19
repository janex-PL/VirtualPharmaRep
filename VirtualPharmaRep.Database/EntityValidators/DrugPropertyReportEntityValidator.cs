using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DrugPropertyReportEntityValidator : BaseEntityValidator<DrugPropertyReport,ApplicationDbContext>
    {
        public DrugPropertyReportEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
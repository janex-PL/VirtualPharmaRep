using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class DrugReportEntityValidator : BaseEntityValidator<DrugReport,ApplicationDbContext>
    {
        public DrugReportEntityValidator(ApplicationDbContext context) : base(context)
        {
        }
    }
}
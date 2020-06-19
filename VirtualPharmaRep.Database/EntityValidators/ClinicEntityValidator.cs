using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
    public class ClinicEntityValidator : BaseEntityValidator<Clinic,ApplicationDbContext>
    {
	    public ClinicEntityValidator(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

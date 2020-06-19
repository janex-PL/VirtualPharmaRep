using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Database.EntityValidators
{
	public class DoctorEntityValidator : BaseEntityValidator<Doctor,ApplicationDbContext>
	{
		public DoctorEntityValidator(ApplicationDbContext context) : base(context)
		{
		}
	}
}
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class ClinicRepository : BaseRepository<Clinic,ApplicationDbContext>
	{
		public ClinicRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DoctorRepository : BaseRepository<Doctor,ApplicationDbContext>
	{
		public DoctorRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
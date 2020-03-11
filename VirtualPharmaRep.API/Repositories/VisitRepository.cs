using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class VisitRepository : BaseRepository<Visit,ApplicationDbContext>
	{
		public VisitRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
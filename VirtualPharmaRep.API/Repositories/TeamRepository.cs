using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class TeamRepository : BaseRepository<Team,ApplicationDbContext>
	{
		public TeamRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DrugRepository : BaseRepository<Drug,ApplicationDbContext>
	{
		public DrugRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
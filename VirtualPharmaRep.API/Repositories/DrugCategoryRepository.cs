using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DrugCategoryRepository : BaseRepository<DrugCategory,ApplicationDbContext>
	{
		public DrugCategoryRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
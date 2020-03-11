using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DrugPropertyRepository : BaseRepository<DrugProperty,ApplicationDbContext>
	{
		public DrugPropertyRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
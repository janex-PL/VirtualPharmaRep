using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class DrugPropertyReportRepository : BaseRepository<DrugPropertyReport,ApplicationDbContext>
	{
		public DrugPropertyReportRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
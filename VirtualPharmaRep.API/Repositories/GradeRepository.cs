using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class GradeRepository : BaseRepository<Grade,ApplicationDbContext>
	{
		public GradeRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class GradeRepository : BaseRepository<Grade,ApplicationDbContext>
    {
	    public GradeRepository(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

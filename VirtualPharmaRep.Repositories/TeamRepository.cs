using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class TeamRepository : BaseRepository<Team,ApplicationDbContext>
    {
	    public TeamRepository(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

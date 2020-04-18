using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class ClinicRepository : BaseRepository<Clinic,ApplicationDbContext>
    {
	    public ClinicRepository(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

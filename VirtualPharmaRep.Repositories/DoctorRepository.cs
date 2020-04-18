using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DoctorRepository : BaseRepository<Doctor,ApplicationDbContext>
    {
	    public DoctorRepository(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

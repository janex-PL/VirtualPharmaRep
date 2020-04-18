using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class VisitRepository : BaseRepository<Visit,ApplicationDbContext>
    {
	    public VisitRepository(ApplicationDbContext context) : base(context)
	    {
	    }

	    public async Task<List<Visit>> GetByEmployment(int employmentId) =>
		    await Context.Set<Visit>().Where(v => v.DoctorEmploymentId == employmentId).ToListAsync();
		
	    public async Task<List<Visit>> GetByUser(string userId) =>
		    await Context.Set<Visit>().Where(v => v.UserId == userId).ToListAsync();
    }
}

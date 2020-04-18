using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DrugPropertyRepository : BaseRepository<DrugProperty,ApplicationDbContext>
    {
	    public DrugPropertyRepository(ApplicationDbContext context) : base(context)
	    {
			
	    }
	    public async Task<List<DrugProperty>> GetByDrug(int drugId) =>
		    await Context.Set<DrugProperty>().Where(dp => dp.DrugId == drugId).ToListAsync();
	}
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DrugRepository : BaseRepository<Drug,ApplicationDbContext>
    {
	    public DrugRepository(ApplicationDbContext context) : base(context)
	    {
	    }

	    public async Task<List<Drug>> GetByCategory(int categoryId) =>
		    await Context.Set<Drug>().Where(drug => drug.DrugCategoryId == categoryId).ToListAsync();
    }
}

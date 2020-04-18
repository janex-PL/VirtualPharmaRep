using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DrugCategoryRepository : BaseRepository<DrugCategory,ApplicationDbContext>
    {
	    public DrugCategoryRepository(ApplicationDbContext context) : base(context)
	    {
	    }
    }
}

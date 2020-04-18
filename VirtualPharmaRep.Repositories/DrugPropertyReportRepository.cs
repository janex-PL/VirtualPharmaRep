using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.Repositories
{
    public class DrugPropertyReportRepository : BaseRepository<DrugPropertyReport,ApplicationDbContext>
    {
	    public DrugPropertyReportRepository(ApplicationDbContext context) : base(context)
	    {
	    }

	    public async Task<List<DrugPropertyReport>> GetByVisit(int visitId) =>
		    await Context.Set<DrugPropertyReport>().Where(dpr => dpr.VisitId == visitId).ToListAsync();

	    public async Task<List<DrugPropertyReport>> GetByProperty(int propertyId) => await Context
		    .Set<DrugPropertyReport>().Where(dpr => dpr.DrugPropertyId == propertyId).ToListAsync();
    }
}

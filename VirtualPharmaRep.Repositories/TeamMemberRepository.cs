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
    public class TeamMemberRepository : BaseRepository<TeamMember,ApplicationDbContext>
    {
	    public TeamMemberRepository(ApplicationDbContext context) : base(context)
	    {
	    }

	    public async Task<List<TeamMember>> GetByTeam(int teamId) =>
		    await Context.Set<TeamMember>().Where(tm => tm.TeamId == teamId).ToListAsync();

    }
}

using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;

namespace VirtualPharmaRep.API.Repositories
{
	public class TeamMemberRepository : BaseRepository<TeamMember,ApplicationDbContext>
	{
		public TeamMemberRepository(ApplicationDbContext context) : base(context)
		{
			
		}
	}
}
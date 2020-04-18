using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface ITeamMemberService
    {
		TeamMember[] GetAllTeamMembers();
		TeamMember GetTeamMember(int id);
		TeamMember AddTeamMember(TeamMember newTeamMember);
		TeamMember EditTeamMember(TeamMember newTeamMember);
		TeamMember DeleteTeamMember(int id);
	}
}

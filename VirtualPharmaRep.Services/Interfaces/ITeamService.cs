using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Services.Interfaces
{
    public interface ITeamService
    {
		Team[] GetAllTeams();
		Team GetTeam(int id);
		Team AddTeam(Team newTeam);
		Team EditTeam(Team newTeam);
		Team DeleteTeam(int id);
	}
}

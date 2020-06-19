using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class TeamMemberDto : IDto
	{
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TeamId { get; set; }
        public bool IsLeader { get; set; }
    }
}
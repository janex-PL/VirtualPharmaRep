using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class TeamMemberViewModel : IViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public bool IsLeader { get; set; }
	}
}
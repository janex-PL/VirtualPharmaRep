using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class TeamMember : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public int TeamId { get; set; }

		[Required]
		public bool IsLeader { get; set; }

		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }

		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
	}
}
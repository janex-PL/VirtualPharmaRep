using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class TeamMember : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		[Required]
		public string UserId { get; set; }

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
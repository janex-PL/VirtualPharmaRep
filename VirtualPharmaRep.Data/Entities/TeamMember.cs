using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class TeamMember : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
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
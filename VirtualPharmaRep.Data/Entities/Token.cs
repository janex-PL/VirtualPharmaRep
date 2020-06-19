using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPharmaRep.Data.Entities
{
	public class Token
	{
		[Key]
		public int Id { get; set; }
        public string ClientId { get; set; }
		public int Type { get; set; }
		[Required]
		public string Value { get; set; }
		[Required]
		public string UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }
	}
}
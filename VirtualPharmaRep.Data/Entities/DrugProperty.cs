using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class DrugProperty : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		public int DrugId { get; set; }
		[Required]
        [MaxLength(50)]
		public string Title { get; set; }
		public string Description { get; set; }
		[ForeignKey("DrugId")]
		public virtual Drug Drug { get; set; }
		public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
	}
}
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Drug : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		public int DrugCategoryId { get; set; }
		[Required]
        [MaxLength(50)]
		public string Name { get; set; }
		public string Description { get; set; }
		[ForeignKey("DrugCategoryId")]
		public virtual DrugCategory DrugCategory { get; set; }
		public virtual List<DrugProperty> DrugProperties { get; set; }
		public virtual List<DrugReport> DrugReports { get; set; }
	}
}
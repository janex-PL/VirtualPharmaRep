using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class DrugCategory : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
        [MaxLength(50)]
		public string Name { get; set; }
		public virtual List<Drug> Drugs { get; set; }
	}
}
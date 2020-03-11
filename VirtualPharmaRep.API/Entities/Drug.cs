using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class Drug : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int DrugCategoryId { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		[ForeignKey("DrugCategoryId")]
		public virtual DrugCategory DrugCategory { get; set; }

		public virtual List<DrugProperty> DrugProperties { get; set; }
	}
}
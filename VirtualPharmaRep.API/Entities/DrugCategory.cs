using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class DrugCategory : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual List<Drug> Drugs { get; set; }
	}
}
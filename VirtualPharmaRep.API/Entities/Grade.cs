using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class Grade : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
	}
}
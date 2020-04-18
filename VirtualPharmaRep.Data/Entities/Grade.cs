using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Grade : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
	}
}
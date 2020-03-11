﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class DrugProperty : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int DrugId { get; set; }

		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		[ForeignKey("DrugId")]
		public virtual Drug Drug { get; set; }

		public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
	}
}
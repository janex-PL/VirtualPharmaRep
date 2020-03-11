using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class Visit : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int DoctorEmploymentId { get; set; }

		[Required]
		public int UserId { get; set; }

		public string Description { get; set; }

		[Required]
		public DateTime VisitDateTime { get; set; }

		[ForeignKey("DoctorEmploymentId")]
		public virtual DoctorEmployment DoctorEmployment { get; set; }

		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }

		public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
	}
}
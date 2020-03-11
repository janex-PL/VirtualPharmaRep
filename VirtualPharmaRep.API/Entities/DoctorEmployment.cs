using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class DoctorEmployment : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int DoctorId { get; set; }

		[Required]
		public int ClinicId { get; set; }

		[Required]
		public bool IsCurrentJob { get; set; }

		[Required]
		public string JobTitle { get; set; }

		[ForeignKey("DoctorId")]
		public virtual Doctor Doctor { get; set; }

		[ForeignKey("ClinicId")]
		public virtual Clinic Clinic { get; set; }

		public virtual List<Visit> Visits { get; set; }
	}
}
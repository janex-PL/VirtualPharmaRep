using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class DoctorEmployment : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		public int DoctorId { get; set; }
		[Required]
		public int ClinicId { get; set; }
		[Required]
        [MaxLength(50)]
		public string JobTitle { get; set; }
		[Required]
		public bool IsJobActive { get; set; }
		[ForeignKey("DoctorId")]
		public virtual Doctor Doctor { get; set; }
		[ForeignKey("ClinicId")]
		public virtual Clinic Clinic { get; set; }
		public virtual List<Visit> Visits { get; set; }
	}
}
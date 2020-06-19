using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Visit : IEntity, ISoftDeletable, IPrivateResource
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsPublished { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		public int DoctorEmploymentId { get; set; }
		[Required]
		public string UserId { get; set; }
		public string Description { get; set; }
		[Required]
		public DateTime VisitDateTime { get; set; }
		[ForeignKey("DoctorEmploymentId")]
		public virtual DoctorEmployment DoctorEmployment { get; set; }
		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }
		public virtual List<DrugReport> DrugReports { get; set; }
	}
}
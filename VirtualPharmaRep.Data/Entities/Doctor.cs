using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Doctor : IEntity, ISoftDeletable
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
		public string FirstName { get; set; }
		[Required]
        [MaxLength(75)]
		public string LastName { get; set; }
		[Required]
        [MaxLength(50)]
		public string Title { get; set; }
		public virtual List<DoctorEmployment> DoctorEmployments { get; set; }
	}
}
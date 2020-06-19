using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Clinic : IEntity, ISoftDeletable
	{
		[Key]
		public int Id { get; set; }
		[Required]
        public string CreatedBy { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		[MaxLength(200)]
        public string Name { get; set; }
		[Required]
		[MaxLength(100)]
        public string Address { get; set; }
		[Required]
		[MaxLength(10)]
		public string PostalCode { get; set; }
		[Required]
		[MaxLength(50)]
		public string City { get; set; }
		[Required]
		[MaxLength(50)]
		public string Province { get; set; }
        public virtual List<DoctorEmployment> DoctorEmployments { get; set; }
    }
}
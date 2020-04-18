using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Clinic : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public string PostalCode { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Province { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		public virtual List<DoctorEmployment> DoctorEmployments { get; set; }
	}
}
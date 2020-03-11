using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
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
		public string County { get; set; }

		public virtual List<DoctorEmployment> DoctorEmployments { get; set; }
	}
}
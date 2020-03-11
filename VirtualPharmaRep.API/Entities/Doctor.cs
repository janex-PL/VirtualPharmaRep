using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class Doctor : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Title { get; set; }

		public virtual List<DoctorEmployment> DoctorEmployments { get; set; }
	}
}
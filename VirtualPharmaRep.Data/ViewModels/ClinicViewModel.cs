using System;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class ClinicViewModel : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Address { get; set; }

		public string PostalCode { get; set; }

		public string City { get; set; }

		public string Province { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public DateTime LastModifiedDateTime { get; set; }
	}
}
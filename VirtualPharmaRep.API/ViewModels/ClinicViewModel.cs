using VirtualPharmaRep.API.ViewModels.Interfaces;

namespace VirtualPharmaRep.API.ViewModels
{
	public class ClinicViewModel : IViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public string PostalCode { get; set; }

		public string City { get; set; }

		public string County { get; set; }
	}
}
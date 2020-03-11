using VirtualPharmaRep.API.ViewModels.Interfaces;

namespace VirtualPharmaRep.API.ViewModels
{
	public class DoctorViewModel : IViewModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Title { get; set; }
	}
}
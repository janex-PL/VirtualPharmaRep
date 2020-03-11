using VirtualPharmaRep.API.ViewModels.Interfaces;

namespace VirtualPharmaRep.API.ViewModels
{
	public class DrugViewModel : IViewModel
	{
		public int Id { get; set; }

		public int DrugCategoryId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
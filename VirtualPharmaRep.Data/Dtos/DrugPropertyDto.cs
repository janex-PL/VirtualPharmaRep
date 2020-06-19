using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class DrugPropertyDto : IDto
	{

		public int Id { get; set; }
        public int DrugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
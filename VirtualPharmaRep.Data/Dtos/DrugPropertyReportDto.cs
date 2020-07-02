using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Data.Dtos
{
	public class DrugPropertyReportDto : IDto
	{
        public int Id { get; set; }
        public int DrugReportId { get; set; }
        public int DrugPropertyId { get; set; }
        public string Description { get; set; }
        public Grade Grade { get; set; }
        public DrugReportDto DrugReport { get; set; }
        public DrugPropertyDto DrugProperty { get; set; }
    }
}
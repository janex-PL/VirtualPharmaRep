using System.Collections.Generic;
using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class DrugPropertyDto : IDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DrugDto Drug { get; set; }
        public IEnumerable<DrugPropertyReportDto> DrugPropertyReports { get; set; }
    }
}
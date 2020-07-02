using System.Collections.Generic;
using VirtualPharmaRep.Data.Dtos.Interfaces;

namespace VirtualPharmaRep.Data.Dtos
{
	public class DrugDto : IDto
	{
        public int Id { get; set; }
        public int DrugCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DrugCategoryDto DrugCategory { get; set; }
        public IEnumerable<DrugPropertyDto> DrugProperties { get; set; }
        public IEnumerable<DrugReportDto> DrugReports { get; set; }
    }
}
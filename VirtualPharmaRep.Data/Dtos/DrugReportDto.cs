using System.Collections.Generic;
using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Data.Dtos
{
    public class DrugReportDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public KnowledgeGrade KnowledgeGrade { get; set; }
        public VisitDto Visit { get; set; }
        public DrugDto Drug { get; set; }
        public IEnumerable<DrugPropertyReport> DrugPropertyReports { get; set; }
    }

}

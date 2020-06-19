using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Entities;

namespace VirtualPharmaRep.Data.Dtos
{
    public class DrugReportDto : IDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public KnowledgeGrade KnowledgeGrade { get; set; }
        public int VisitId { get; set; }
        public int DrugId { get; set; }
    }

}

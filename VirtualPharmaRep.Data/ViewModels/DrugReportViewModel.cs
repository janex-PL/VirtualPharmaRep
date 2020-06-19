using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class DrugReportViewModel : IViewModel
    {
        public string Description { get; set; }
        [Required]
        public KnowledgeGrade KnowledgeGrade { get; set; }
        [Required]
        public int VisitId { get; set; }
        [Required]
        public int DrugId { get; set; }
    }
}
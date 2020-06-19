using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class DrugPropertyReportViewModel : IViewModel
    {
        [Required]
        public int DrugReportId { get; set; }
        [Required]
        public int DrugPropertyId { get; set; }
        public string Description { get; set; }
        [Required]
        public Grade Grade { get; set; }
    }
}
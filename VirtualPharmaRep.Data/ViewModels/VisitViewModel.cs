using System;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class VisitViewModel : IViewModel
    {
        [Required]
        public int DoctorEmploymentId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime VisitDateTime { get; set; }
	}
}
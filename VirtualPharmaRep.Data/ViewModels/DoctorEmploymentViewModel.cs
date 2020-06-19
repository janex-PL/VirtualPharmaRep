using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
    public class DoctorEmploymentViewModel : IViewModel
    {
		[Required]
        public int DoctorId { get; set; }
        [Required]
        public int ClinicId { get; set; }
        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }
        [Required]
        public bool IsJobActive { get; set; }
	}
}
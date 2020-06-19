using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class DoctorViewModel : IViewModel
	{
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
	}
}
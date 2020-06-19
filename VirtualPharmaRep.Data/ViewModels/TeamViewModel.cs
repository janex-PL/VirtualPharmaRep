using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.ViewModels.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class TeamViewModel : IViewModel
	{
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
	}
}
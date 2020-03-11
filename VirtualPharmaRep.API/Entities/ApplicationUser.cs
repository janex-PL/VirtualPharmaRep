using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string PasswordHashSalt { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }


		public virtual List<TeamMember> TeamMembers { get; set; }

		public virtual List<Visit> Visits { get; set; }
	}
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VirtualPharmaRep.Data.Entities
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		[Required]
		public string LastName { get; set; }

		public virtual List<TeamMember> TeamMembers { get; set; }

		public virtual List<Visit> Visits { get; set; }

		public virtual List<Token> Tokens { get; set; }
	}
}
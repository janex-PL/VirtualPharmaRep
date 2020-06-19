using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class ApplicationUser : IdentityUser, ISoftDeletable
	{
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        [Required]
        [MaxLength(50)]
		public string FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        public virtual List<TeamMember> TeamMembers { get; set; }
        public virtual List<Visit> Visits { get; set; }
        public virtual List<Token> Tokens { get; set; }
        
    }
}
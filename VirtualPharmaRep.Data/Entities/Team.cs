using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class Team : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual List<TeamMember> TeamMembers { get; set; }
	}
}
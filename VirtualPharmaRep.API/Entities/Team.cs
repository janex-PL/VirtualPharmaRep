using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class Team : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual List<TeamMember> TeamMembers { get; set; }
	}
}
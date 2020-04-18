using System;

namespace VirtualPharmaRep.Data.Entities.Interfaces
{
	public interface IEntity
	{
		int Id { get; set; }

		DateTime CreatedDateTime { get; set; }

		DateTime LastModifiedDateTime { get; set; }
	}
}
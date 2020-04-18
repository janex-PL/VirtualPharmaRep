using System;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.ViewModels
{
	public class DrugViewModel : IEntity
	{
		public int Id { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public DateTime LastModifiedDateTime { get; set; }

		public int DrugCategoryId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
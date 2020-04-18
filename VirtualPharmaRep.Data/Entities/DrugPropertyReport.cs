using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class DrugPropertyReport : IEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime CreatedDateTime { get; set; }

		[Required]
		public DateTime LastModifiedDateTime { get; set; }

		[Required]
		public int GradeId { get; set; }

		[Required]
		public int DrugPropertyId { get; set; }

		[Required]
		public int VisitId { get; set; }

		public string Description { get; set; }

		[ForeignKey("GradeId")]
		public virtual Grade Grade { get; set; }

		[ForeignKey("DrugPropertyId")]
		public virtual DrugProperty DrugProperty { get; set; }

		[ForeignKey("VisitId")]
		public virtual Visit Visit { get; set; }
	}
}
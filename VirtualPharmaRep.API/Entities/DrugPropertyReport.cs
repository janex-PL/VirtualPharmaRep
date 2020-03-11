using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.API.Entities.Interfaces;

namespace VirtualPharmaRep.API.Entities
{
	public class DrugPropertyReport : IEntity
	{
		[Key]
		public int Id { get; set; }

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
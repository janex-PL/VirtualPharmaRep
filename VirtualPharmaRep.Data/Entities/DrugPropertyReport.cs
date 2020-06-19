using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
	public class DrugPropertyReport : IEntity, ISoftDeletable, IPrivateResource
	{
		[Key]
		public int Id { get; set; }
        [Required]
        public string CreatedBy { get; set; }
		[Required]
		[DefaultValue(false)]
        public bool IsPublished { get; set; }
		[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
		[Required]
		public int DrugReportId { get; set; }
		[Required]
		public int DrugPropertyId { get; set; }
        public string Description { get; set; }
		[Required]
		public Grade Grade { get; set; }
        [ForeignKey("DrugPropertyId")]
		public virtual DrugProperty DrugProperty { get; set; }
    }

    public enum Grade
    {
		Negative,Neutral,Positive
    }
}
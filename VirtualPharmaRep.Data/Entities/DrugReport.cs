using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Entities
{
    public class DrugReport : IEntity, ISoftDeletable, IPrivateResource
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
        public string Description { get; set; }
        [Required]
        public KnowledgeGrade KnowledgeGrade { get; set; }
        [Required]
        public int VisitId { get; set; }
        [Required]
        public int DrugId { get; set; }
        [ForeignKey("VisitId")]
        public virtual Visit Visit { get; set; }
        [ForeignKey("DrugId")]
        public virtual Drug Drug { get; set; }
        public virtual List<DrugPropertyReport> DrugPropertyReports { get; set; }
    }

    public enum KnowledgeGrade
    {
        NotKnown, NotUsing, Using
    }
}

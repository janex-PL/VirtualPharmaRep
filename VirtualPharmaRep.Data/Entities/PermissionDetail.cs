using System.ComponentModel.DataAnnotations;

namespace VirtualPharmaRep.Data.Entities
{
    public class PermissionDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
        [Required]
        public int PermissionRank { get; set; }
        [Required]
        [MaxLength(45)]
        public string PermissionLevels { get; set; }
    }
}

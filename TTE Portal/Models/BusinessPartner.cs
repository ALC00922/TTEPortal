using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class BusinessPartner
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string BpCode { get; set; }

        [Required]
        [MaxLength(500)]
        public string BpName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }
    }
}

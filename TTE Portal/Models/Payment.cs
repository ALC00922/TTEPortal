using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string BpCode { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public string ItemBrand { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Payments { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }
    }
}

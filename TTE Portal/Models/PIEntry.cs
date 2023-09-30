using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class PIEntry
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string BpCode { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [MaxLength(500)]
        public string ItemCode { get; set; }

        [MaxLength(50)]
        public string ItemColor { get; set; }

        [MaxLength(50)]
        public string ItemBrand { get; set; }

        [MaxLength(500)]
        public string ItemDesc { get; set; }

        public int? ItemQty { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ItemPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PIValue { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }
    }
}

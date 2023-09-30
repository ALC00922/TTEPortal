using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class Delivery
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string ItemCode { get; set; }

        public int? ItemQty { get; set; }

        [MaxLength(50)]
        public string ItemColor { get; set; }

        [MaxLength(50)]
        public string ItemBrand { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        public string BpCode { get; set; }

        [MaxLength(50)]
        public string PIEntry { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }
    }
}

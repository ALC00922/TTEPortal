using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class AwbEntry
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string LcNo { get; set; }

        [MaxLength(50)]
        public string BpCode { get; set; }

        [MaxLength(50)]
        public string PINo { get; set; }

        [MaxLength(500)]
        public string AwbFile { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }

    }
}

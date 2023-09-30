using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TTE_Portal.Areas.Identity.Data;

namespace TTE_Portal.Models
{
    public class Log
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Activty { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Describtion { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public int? ItemID { get; set; }

        [MaxLength(50)]
        public string ItemType { get; set; }

        [ForeignKey("CreatedBy")]
        public ApplicationUser User { get; set; }
    }
}

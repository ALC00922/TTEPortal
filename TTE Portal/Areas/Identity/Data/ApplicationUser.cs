using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TTE_Portal.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string BpCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleCode { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [MaxLength(500)]
        public string FullName { get; set; }
        
    }
}

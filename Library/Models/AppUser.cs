using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class AppUser:IdentityUser
    {


        //extending from Identity User
        [StringLength(100)]
        [MaxLength(100)]
        [Required]
        public string? Name  { get; set; }
        public string? Address { get; set; }
        
    }
}

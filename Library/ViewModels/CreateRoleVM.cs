using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{


        public class CreateRoleVM
        {
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        }
    
}

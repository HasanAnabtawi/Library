using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Password don't match")]
        public string? ConfirmPassword { get; set; }
        public string? Address { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "ID Number is required")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID Number must be exactly 13 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "ID Number must contain only digits")]
        [Display(Name = "Identity Number")]
        public string IdNumber { get; set; }
    }
}


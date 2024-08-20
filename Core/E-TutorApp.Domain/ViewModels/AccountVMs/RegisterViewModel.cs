using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_TutorApp.Domain.ViewModels.AccountVMs
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(50, ErrorMessage = "Firstname cannot be longer than 50 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [StringLength(50, ErrorMessage = "LastName cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [PasswordPropertyText]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "RePassword is required.")]
        [Compare("Password", ErrorMessage = "Password and RePassword do not match.")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "You must accept the terms and conditions.")]

        public bool Conditions { get; set; } = false;
    }
}

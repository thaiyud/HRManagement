using System.ComponentModel.DataAnnotations;

namespace HRManagement.DTO
{
    public class SignUpDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 50 characters.")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }
    }
}

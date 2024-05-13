using System.ComponentModel.DataAnnotations;

namespace HRManagement.DTO
{
    public class SignInDTO
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;

namespace POS.Application.DTOs.User
{
    public class CreateUserRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "Password must contain atleast 8 chracters.")]
        public string Password { get; set; } = string.Empty;
    }
}

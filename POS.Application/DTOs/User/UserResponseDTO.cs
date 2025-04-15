using POS.Domain.Enums;

namespace POS.Application.DTOs.User
{
    public class UserResponseDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public UserRole Role { get; set; }  
    }
}

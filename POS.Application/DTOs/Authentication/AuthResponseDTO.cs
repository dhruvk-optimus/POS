namespace POS.Application.DTOs.Authentication
{
    public class AuthResponseDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Role { get; set; } = default!;
        public string Token { get; set; } = default!;
    }

}

using System.ComponentModel.DataAnnotations;
using POS.Domain.Enums;

namespace POS.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Key]
        public Guid UserId {  get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password {  get; set; } = string.Empty;

        [Required]
        public UserRole Role { get; set; } = UserRole.Customer;


        public ICollection<OrderEntity> Orders { get;  set; } = new List<OrderEntity>();


    }
}

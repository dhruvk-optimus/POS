using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using POS.Domain.Enums;

namespace POS.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        [Key]
        public Guid OrderId {get; set; } = Guid.NewGuid();
        public OrderStatus Status { get; set; }

        public decimal TotalAmount { get; set; }
        

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        
        public UserEntity User { get; set; } = default!;

        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>(); 


    }
}

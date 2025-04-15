using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Domain.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        [Key]
        public Guid OrderItemId { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }


        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; } = default!;


        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }
        public ItemEntity Item { get; set; } = default!;

    }
}

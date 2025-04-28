using System.ComponentModel.DataAnnotations;

namespace POS.Domain.Entities
{
    public class ItemEntity : BaseEntity
    {
        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AvailableStock { get; set; }

        //[Timestamp]
        //public byte[]? RowVersion { get; set; }

        public ICollection<OrderItemEntity> OrderItems { get; set; } = new List<OrderItemEntity>();
    }
}

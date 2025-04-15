using System.ComponentModel.DataAnnotations;

namespace POS.Application.DTOs.Item
{
    public class AddItemRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Available stock must be at least 1.")]
        public int AvailableStock { get; set; }
    }
}

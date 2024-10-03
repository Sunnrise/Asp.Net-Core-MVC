using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public record ProductDTO
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "ProductName is required")]
        public String? ProductName { get; init; } = String.Empty;

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; init; }
        public int? CategoryId { get; init; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100000)]
        public decimal Price { get; set; }

        [Range(0, 10000)]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
    }
}
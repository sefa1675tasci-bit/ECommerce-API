using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.DTOs
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
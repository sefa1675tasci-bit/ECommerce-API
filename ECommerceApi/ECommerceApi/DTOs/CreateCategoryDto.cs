using System.ComponentModel.DataAnnotations;

namespace ECommerceApi.DTOs
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
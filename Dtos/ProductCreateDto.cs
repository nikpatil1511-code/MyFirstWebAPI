using System.ComponentModel.DataAnnotations;

namespace MyFirstWebAPI.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}

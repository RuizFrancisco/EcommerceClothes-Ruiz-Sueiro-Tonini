using System.ComponentModel.DataAnnotations;

namespace EcommerceClothes.Models
{
    public class ProductPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}

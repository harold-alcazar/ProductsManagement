using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.Domain.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]  
        public decimal Price { get; set; }
        [Required]
        public int InitialQuantity { get; set; }
    }
}

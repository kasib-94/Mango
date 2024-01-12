using System.ComponentModel.DataAnnotations;

using Mango.Web.Utility;

namespace Mango.Web.Models
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 100)]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        [Range(1, 100)]
        public int Count { get; set; } = 1;
        [MaxFileSize(1)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile? Image { get; set; }
    }
}

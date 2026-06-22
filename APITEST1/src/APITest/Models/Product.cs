using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name là bắt buộc")]
        [MinLength(3, ErrorMessage = "Name phải có ít nhất 3 ký tự")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Price là bắt buộc")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price phải lớn hơn 0")]
        public decimal Price { get; set; }
    }
}
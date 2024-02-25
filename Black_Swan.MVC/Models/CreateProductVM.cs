using System.ComponentModel.DataAnnotations;

namespace Black_Swan.MVC.Models
{
    public class CreateProductVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The name field must have at least 1 character and at most 100 characters.")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The count field must be a non-negative integer.")]
        public int Count { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The price field must be a non-negative number.")]
        public float Price { get; set; }
        [StringLength(500, ErrorMessage = "The description field cannot exceed 500 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The size field is required.")]
        public string Size { get; set; }
        [Required(ErrorMessage = "The color field is required.")]
        public string Color { get; set; }
        public byte[]? Img { get; set; }
        public bool IsAvalaible { get; set; }
        public string Sellerid { get; set; }
        [Required(ErrorMessage = "The brandId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The brandId field must be a positive integer.")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "The cityId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The cityId field must be a positive integer.")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "The productCategoryId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The productCategoryId field must be a positive integer.")]
        public int ProductCategoryId { get; set; }
    }
}

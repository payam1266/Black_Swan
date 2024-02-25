using System.ComponentModel.DataAnnotations;

namespace Black_Swan.MVC.Models
{
    public class ProductVM
    {
        public int id { get; set; }
        [Required(ErrorMessage = "The name field is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The name field must have at least 1 character and at most 100 characters.")]
        public string name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "The count field must be a non-negative integer.")]
        public int count { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The price field must be a non-negative number.")]
        public float price { get; set; }
        [StringLength(500, ErrorMessage = "The description field cannot exceed 500 characters.")]
        public string? description { get; set; }
        [Required(ErrorMessage = "The size field is required.")]
        public string size { get; set; }
        [Required(ErrorMessage = "The color field is required.")]
        public string color { get; set; }
        public byte[]? img { get; set; }
        public bool IsAvalaible { get; set; }
        public string? sellerid { get; set; }
        [Required(ErrorMessage = "The brandId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The brandId field must be a positive integer.")]
        public int brandId { get; set; }
       
        public BrandVM? brand { get; set; }
        [Required(ErrorMessage = "The cityId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The cityId field must be a positive integer.")]
        public int cityId { get; set; }
        public CityVM? city { get; set; }
        [Required(ErrorMessage = "The productCategoryId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The productCategoryId field must be a positive integer.")]
        public int productCategoryId { get; set; }
        public ProductCategoryVM? productCategory { get; set; }
    }
}

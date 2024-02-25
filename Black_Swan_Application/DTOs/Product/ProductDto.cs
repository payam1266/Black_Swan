using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.DTOs.Common;
using Black_Swan_Application.DTOs.ProductCategory;

namespace Black_Swan_Application.DTOs.Product
{
    public class ProductDto:BaseDTOs,IProductDto
    {
        public string name { get; set; }
        public int count { get; set; }
        public float price { get; set; }
        public string? description { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public byte[]? img { get; set; }
        public bool IsAvalaible { get; set; }
        public string? sellerid { get; set; }
        public int brandId { get; set; }
        public BrandDto? brand { get; set; }
        public int cityId { get; set; }
        public CityDto? city { get; set; }
        public int productCategoryId { get; set; }
        public ProductCategoryDto? productCategory { get; set; }
        //public ApplicationUser seller { get; set; }
    }
}

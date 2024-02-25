using Black_Swan_Application.DTOs.Common;
using Black_Swan_Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.DTOs.ProductCategory
{
    public class ProductCategoryDto:BaseDTOs
    {
        public string name { get; set; }
        //public ICollection<ProductDto>? products { get; set; }
    }
}

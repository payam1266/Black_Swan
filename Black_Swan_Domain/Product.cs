using Black_Swan_Domain.common;
using System.Collections.Generic;

namespace Black_Swan_Domain
{
    public class Product:BaseDomainEntity
    {

        public string name { get; set; }
        public int count { get; set; }

        public float price { get; set; }

       
        public string? description { get; set; }

        public string size { get; set; }

        public string color { get; set; }
        public bool IsAvalaible { get; set; }
       
        public string? sellerid { get; set; }
       
        public int brandId { get; set; }
       
        public Brand? brand { get; set; }
        public int cityId { get; set; }
    
        public City? city { get; set; }
  
        public byte[]? img { get; set; }
        public int productCategoryId { get; set; }
       
        public ProductCategory? productCategory { get; set; }
        public ICollection<OrderDetails>? orderDetails { get; set; }

        //public ApplicationUser seller { get; set; }
    }
}

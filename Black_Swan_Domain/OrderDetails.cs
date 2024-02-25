using Black_Swan_Domain.common;

namespace Black_Swan_Domain
{
    public class OrderDetails:BaseDomainEntity
    {
       
        public int orderId { get; set; }
        //[ForeignKey("orderId")]
        public Order? Order { get; set; }
        public int productId { get; set; }
        //[ForeignKey("productId")]
        public Product? product { get; set; }
        public string productName { get; set; }
        public float productPrice { get; set; }
        public int quantity { get; set; }
        public float subtotal { get; set; }
    }
}

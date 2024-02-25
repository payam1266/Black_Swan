using Black_Swan_Application.DTOs.Common;
using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.DTOs.Product;

namespace Black_Swan_Application.DTOs.OrderDetails
{
    public class OrderDetailsDto:BaseDTOs
    {
        public int orderId { get; set; }
        public OrderDto? Order { get; set; }
        public int productId { get; set; }
        public ProductDto? product { get; set; }
        public string? productName { get; set; }
        public float productPrice { get; set; }
        public int quantity { get; set; }
        public float subtotal { get; set; }
    }
}

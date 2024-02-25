namespace Black_Swan.MVC.Models
{
    public class OrderDetailsVM
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public OrderVM Order { get; set; }

        public int ProductId { get; set; }

        public ProductVM Product { get; set; }

        public string ProductName { get; set; }

        public float ProductPrice { get; set; }

        public int Quantity { get; set; }

        public float Subtotal { get; set; }
    }
}

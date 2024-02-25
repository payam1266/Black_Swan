namespace Black_Swan.MVC.Models
{
    public class OrderVM
    {
        public enum OrderStatus
        {
            PendingPayment,
            Paid,
            InPreparation,
            Canceled
        }
        public int Id { get; set; }

        public string Customerid { get; set; }

        public string Paymentmethod { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Postalcode { get; set; }

        public float TotalPrice { get; set; }

        public OrderStatus Status { get; set; }
    }
}

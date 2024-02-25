using Black_Swan_Application.DTOs.Common;
using Black_Swan_Application.DTOs.OrderDetails;
using System.Collections.Generic;
namespace Black_Swan_Application.DTOs.Order
{
    public class OrderDto:BaseDTOs
    {
        public enum OrderStatus
        {
            PendingPayment,
            Paid,
            InPreparation,
            Canceled
        }
        public string customerid { get; set; }
        public string paymentmethod { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string postalcode { get; set; }
        public float totalPrice { get; set; }
        public OrderStatus status { get; set; }
       
    }
}

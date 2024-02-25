using Black_Swan_Domain.common;
using System.Collections;
using System.Collections.Generic;
namespace Black_Swan_Domain
{
    public class Order:BaseDomainEntity
    {
        public enum OrderStatus
        {
            PendingPayment,
            Paid,
            InPreparation,
            Canceled
        }
       
        public string? customerid { get; set; }


        public string paymentmethod { get; set; }

        public string address { get; set; }
        public string phone { get; set; }
        public string city { get; set; }

        public string postalcode { get; set; }
       
        public float totalPrice { get; set; }
        public OrderStatus status { get; set; }
       
    }
}

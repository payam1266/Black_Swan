using Black_Swan_Domain.common;

namespace Black_Swan_Domain
{
    public class CardItem:BaseDomainEntity
    {
       
        public string productname { get; set; }
        public int productcount { get; set; }
        public float productprice { get; set; }
       
        public int productid { get; set; }
        public string? userid { get; set; }
    }
}

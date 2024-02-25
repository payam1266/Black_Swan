using Black_Swan_Application.DTOs.Common;

namespace Black_Swan_Application.DTOs.CardItem
{
    public class CardItemDto:BaseDTOs
    {
        public string productname { get; set; }
        public int productcount { get; set; }
        public float productprice { get; set; }
        public int productid { get; set; }
        public string? userid { get; set; }
    }
}

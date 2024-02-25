using Black_Swan_Application.DTOs.Common;

namespace Black_Swan_Application.DTOs.Brand
{
    public class CreateBrandDto:BaseDTOs
    {
        public string name { get; set; }
        public string? description { get; set; }
    }
}

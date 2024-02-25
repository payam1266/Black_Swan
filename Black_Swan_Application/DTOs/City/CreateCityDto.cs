using Black_Swan_Application.DTOs.Common;

namespace Black_Swan_Application.DTOs.City
{
    public class CreateCityDto : BaseDTOs,ICityDto
    {
        public string name { get; set; }
    }
}

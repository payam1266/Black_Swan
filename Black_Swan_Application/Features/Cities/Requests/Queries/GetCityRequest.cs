using Black_Swan_Application.DTOs.City;
using MediatR;

namespace Black_Swan_Application.Features.Cities.Requests.Queries
{
    public class GetCityRequest:IRequest<CityDto>
    {
        public int id { get; set; }
    }
}

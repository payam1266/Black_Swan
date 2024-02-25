using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.Responses;
using MediatR;

namespace Black_Swan_Application.Features.Cities.Requests.Commands
{
    public class CreateCityCommand:IRequest<BaseCommandResponse>
    {
        public CreateCityDto CityDto { get; set; }
    }
}

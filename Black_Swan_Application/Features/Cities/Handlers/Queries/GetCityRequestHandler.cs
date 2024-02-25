using AutoMapper;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.Exceptions;
using Black_Swan_Application.Features.Cities.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Cities.Handlers.Queries
{
    public class GetCityRequestHandler : IRequestHandler<GetCityRequest, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityRequestHandler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityDto> Handle(GetCityRequest request, CancellationToken cancellationToken)
        {
            
           
            var city = await _cityRepository.GetCity(request.id);
            if(city is null)
            {
               throw new NotFoundException("city",request.id);
            }
            return _mapper.Map<CityDto>(city);
        }
    }
}

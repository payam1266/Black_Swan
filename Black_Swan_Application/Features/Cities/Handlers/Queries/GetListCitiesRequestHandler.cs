using AutoMapper;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.Features.Cities.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Cities.Handlers.Queries
{
    public class GetListCitiesRequestHandler : IRequestHandler<GetListCitiesRequest, List<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetListCitiesRequestHandler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<List<CityDto>> Handle(GetListCitiesRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetListCities();
            return _mapper.Map<List<CityDto>>(city);
        }
    }
}

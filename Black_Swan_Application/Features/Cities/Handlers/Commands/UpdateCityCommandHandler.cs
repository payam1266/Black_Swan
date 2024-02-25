using AutoMapper;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.DTOs.City.Validators;
using Black_Swan_Application.Features.Cities.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Cities.Handlers.Commands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {

            var validator = new ICityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CityDto);
            if (!validationResult.IsValid)
            {
                throw new Exception();
            }


            var city = await _cityRepository.Get(request.CityDto.id);
            if (city == null)
            {
                throw new InvalidOperationException($"City with {request.CityDto.id} ID not find.");
            }
          
            _mapper.Map(request.CityDto,city);
            await _cityRepository.Update(city);
            return Unit.Value;



        }
    }
}

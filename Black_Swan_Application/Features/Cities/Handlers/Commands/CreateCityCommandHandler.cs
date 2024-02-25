using AutoMapper;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.DTOs.City.Validators;
using Black_Swan_Application.DTOs.Product.Validators;
using Black_Swan_Application.Features.Cities.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Cities.Handlers.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, BaseCommandResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository cityRepository,IMapper mapper)
        {
            _cityRepository = cityRepository;
           _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCityDtoValidator(_cityRepository);
            var validatorResult = await validator.ValidateAsync(request.CityDto);
            if (validatorResult.IsValid == false)
            {
                //throw new Exception("error in validation");
                //throw new Exceptions.ValidationException(validatorResult);

                response.success = false;
                response.message = "creation failed";
                response.errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }
            
         
            var city = _mapper.Map<City>(request.CityDto);
            city = await _cityRepository.Add(city);
            response.success = true;
            response.message = "Creation is success.";
            response.id = city.id;
            return response;
            
        }
      
    }
}

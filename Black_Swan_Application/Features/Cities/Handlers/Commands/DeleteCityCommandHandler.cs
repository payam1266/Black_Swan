using AutoMapper;
using Black_Swan_Application.Exceptions;
using Black_Swan_Application.Features.Cities.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Cities.Handlers.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(ICityRepository cityRepository,IMapper mapper)
        {
           _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.Get(request.id);
            if (city == null)
            {
                throw new NotFoundException(nameof(City), request.id);
            }
            await _cityRepository.Delete(city);
            return Unit.Value;
            
        }
    }
}

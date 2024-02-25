using AutoMapper;
using Black_Swan_Application.Features.Brands.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Brands.Handlers.Commands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.Get(request.BrandDto.id);
           _mapper.Map(request.BrandDto,brand);
            await _brandRepository.Update(brand);
            return Unit.Value;
        }
    }
}

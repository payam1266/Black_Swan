using AutoMapper;
using Black_Swan_Application.Exceptions;
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
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brand,IMapper mapper)
        {
            _brandRepository = brand;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.Get(request.id);
            if (brand == null)
            {
                throw new NotFoundException(nameof(Brand), request.id);
            }
            await _brandRepository.Delete(brand);
            return Unit.Value;
                
        }
    }
}

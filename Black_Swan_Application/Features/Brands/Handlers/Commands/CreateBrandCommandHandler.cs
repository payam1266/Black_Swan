using AutoMapper;
using Black_Swan_Application.DTOs.Brand.Validators;
using Black_Swan_Application.Features.Brands.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Brands.Handlers.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BaseCommandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)

        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateBrandDtoValidator(_brandRepository);
            var validatorResult = await validator.ValidateAsync(request.BrandDto);
            if (validatorResult.IsValid == false)
            {

                response.success = false;
                response.message = "Creation is fail.";
                response.errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            else
            {
                var brand = _mapper.Map<Brand>(request.BrandDto);
                brand = await _brandRepository.Add(brand);
                response.success = true;
                response.message = "Creation Successful.";
                response.id = brand.id;
            }


            return response;
        }
    }
}

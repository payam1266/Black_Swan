using AutoMapper;
using Black_Swan_Application.DTOs.Product.Validators;
using Black_Swan_Application.Features.Products.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Products.Handlers.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICityRepository _cityRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository,IMapper mapper
            ,IProductCategoryRepository productCategoryRepository,IBrandRepository brandRepository
            ,ICityRepository cityRepository)
        {
           _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _brandRepository = brandRepository;
            _cityRepository = cityRepository;
        }
        public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateProductDtoValidator(_cityRepository, _brandRepository, _productCategoryRepository);
            var validatorResult = await validator.ValidateAsync(request.ProductDto);
            if (validatorResult.IsValid == false)
            {
                //throw new Exception();
                response.success = false;
                response.message = "Update not success";
                response.errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }
            var product = await _productRepository.Get(request.ProductDto.id);
            _mapper.Map(request.ProductDto, product);
            await _productRepository.Update(product);
            //return Unit.Value;
            response.success = true;
            response.message = "Update is success.";
            response.id = product.id;
            return response;
        }
    }
}

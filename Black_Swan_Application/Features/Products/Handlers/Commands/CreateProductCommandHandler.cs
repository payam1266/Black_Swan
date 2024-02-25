using AutoMapper;
using Black_Swan_Application.Contracts.Infrastructure;
using Black_Swan_Application.DTOs.Product.Validators;
using Black_Swan_Application.Features.Products.Requests.Commands;
using Black_Swan_Application.Models;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Products.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly IEmailSender _emailSender;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductCommandHandler(IProductRepository productRepository
            , IMapper mapper, ICityRepository cityRepository, IEmailSender emailSender,
            IBrandRepository brandRepository, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cityRepository = cityRepository;
            _emailSender = emailSender;
            _brandRepository = brandRepository;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var validator = new CreateProductDtoValidator(_cityRepository,
                _productRepository, _brandRepository, _productCategoryRepository);

            var validatorResult = await validator.ValidateAsync(request.ProductDto);
            if (validatorResult.IsValid == false)
            {
                //throw new Exceptions.ValidationException(validatorResult);
                response.success = false;
                response.message = "creation failed";
                response.errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }
            var email = new Email
            {
                To = "payamghaznavi24@gmail.com",
                Subject = "Your Request Submitted",
                Body = $"Your  request for Adding is successful."
            };
            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                //log
            }


            var product = _mapper.Map<Product>(request.ProductDto);
            product = await _productRepository.Add(product);
            response.success = true;
            response.message = "Creation is success.";
            response.id = product.id;
            return response;
        }
    }
}

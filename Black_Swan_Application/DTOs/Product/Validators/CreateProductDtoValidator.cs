using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator:AbstractValidator<CreateProductDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public CreateProductDtoValidator(ICityRepository cityRepository
            ,IProductRepository productRepository
            ,IBrandRepository brandRepository,IProductCategoryRepository productCategoryRepository)
        {
           _cityRepository = cityRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
           _productCategoryRepository = productCategoryRepository;
            Include(new IProductDtoValidator());

            RuleFor(p => p.name).MustAsync(async (name, token) =>
            {
                return await _productRepository.Unique(name);
            }).WithMessage("{PropertyName} is already exists.");

            RuleFor(p => p.cityId).MustAsync(async (id, token) =>
            {
                return await _cityRepository.Exist(id);
            }).WithMessage("Id for cityId Is Not Set.");

            RuleFor(p => p.brandId).MustAsync(async (id, token) =>
            {
                return await _brandRepository.Exist(id);
            }).WithMessage("Id for BrandId Is Not Set.");
            
            RuleFor(p => p.productCategoryId).MustAsync(async (id, token) =>
            {
                return await _productCategoryRepository.Exist(id);
            }).WithMessage(" Id for productCategoryId Is Not Set.");
        }
    }
}

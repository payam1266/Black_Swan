using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;

namespace Black_Swan_Application.DTOs.Product.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IBrandRepository _brandRepository;

        public UpdateProductDtoValidator(ICityRepository cityRepository
            , IBrandRepository brandRepository, IProductCategoryRepository productCategoryRepository)
        {
            _cityRepository = cityRepository;
            _productCategoryRepository = productCategoryRepository;
            _brandRepository = brandRepository;

            Include(new IProductDtoValidator());
            RuleFor(p => p.id).NotNull().WithMessage("{PropertyName} is required.");
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

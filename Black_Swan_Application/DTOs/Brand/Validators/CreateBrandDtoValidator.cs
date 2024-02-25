using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;

namespace Black_Swan_Application.DTOs.Brand.Validators
{
    public class CreateBrandDtoValidator:AbstractValidator<CreateBrandDto>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandDtoValidator(IBrandRepository brandRepository)
        {
         _brandRepository = brandRepository;
            RuleFor(p => p.name).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.name).MustAsync(async (name, token) =>
            {
                return await _brandRepository.Unique(name); 
            }).WithMessage("{PropertyName} is already exists.");

        }

    }
}

using FluentValidation;

namespace Black_Swan_Application.DTOs.Brand.Validators
{
    public class BrandDtoValidator : AbstractValidator<BrandDto>
    {
        public BrandDtoValidator()
        {

            RuleFor(p => p.name).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}

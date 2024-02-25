using FluentValidation;

namespace Black_Swan_Application.DTOs.City.Validators
{
    public class ICityDtoValidator:AbstractValidator<ICityDto>
    {
        public ICityDtoValidator()
        {
            RuleFor(p => p.name).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}

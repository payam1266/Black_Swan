using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;

namespace Black_Swan_Application.DTOs.City.Validators
{
    public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
    {
        private readonly ICityRepository _cityRepository;

        public CreateCityDtoValidator(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;

            Include(new ICityDtoValidator());

            RuleFor(p => p.name).MustAsync(async (name, token) =>
            {
                return await _cityRepository.Unique(name);

            }).WithMessage("{PropertyName} is already exists.");

        }
    }

}

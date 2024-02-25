using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;

namespace Black_Swan_Application.DTOs.CardItem.Validators
{
    public class CardItemDtoValidator:AbstractValidator<CardItemDto>
    {
        
        private readonly IProductRepository _productRepository;
        public CardItemDtoValidator(IProductRepository productRepository)
        {
           _productRepository = productRepository;
            RuleFor(p => p.productname).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p=> p.productcount).NotEmpty().NotNull().WithMessage("{PropertyName} is required.")
                 .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.");
            RuleFor(p => p.productprice).NotEmpty().NotNull()
               .WithMessage("{PropertyName} is required.")
               .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.");
            RuleFor(p => p.productid).MustAsync(async (id, token) =>
            {

                return await _productRepository.Exist(id);
            }).WithMessage(" Id for productId Is Not Set.");
          
        }
    }
}

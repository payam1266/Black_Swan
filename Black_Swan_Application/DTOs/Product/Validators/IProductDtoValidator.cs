using Black_Swan_Application.Persistence.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.DTOs.Product.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        public IProductDtoValidator()
        {
            //RuleFor(p => p.name).NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
            //RuleFor(p => p.date).LessThan(DateTime.Now);
            RuleFor(p => p.count).NotNull()
                 .WithMessage("{PropertyName} is required.")
                 .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be atleast 1.");
            RuleFor(p=> p.price).NotEmpty().NotNull()
                 .WithMessage("{PropertyName} is required.")
                 .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.");
            RuleFor(p => p.color).NotEmpty().NotNull()
                 .WithMessage("{PropertyName} is required.");
            RuleFor(p => p.size).NotEmpty().NotNull()
                 .WithMessage("{PropertyName} is required.");
            RuleFor(p => p.description).NotEmpty().NotNull()
                 .WithMessage("{PropertyName} is required.").MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters."); ;
          

        }
    }
}

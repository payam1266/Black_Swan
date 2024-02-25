using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Black_Swan_Application.Exceptions
{
    public class ValidationException:ApplicationException
    {
        public List<string> errors { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                errors.Add(item.ErrorMessage);
            }
        }
    }
}

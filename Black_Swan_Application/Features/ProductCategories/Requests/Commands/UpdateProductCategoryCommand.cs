using Black_Swan_Application.DTOs.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.ProductCategories.Requests.Commands
{
    public class UpdateProductCategoryCommand:IRequest<Unit>
    {
        public ProductCategoryDto ProductCategoryDto { get; set; }
    }
}

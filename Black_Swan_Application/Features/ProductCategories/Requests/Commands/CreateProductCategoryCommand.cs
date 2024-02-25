using Black_Swan_Application.DTOs.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.ProductCategories.Requests.Commands
{
    public class CreateProductCategoryCommand:IRequest<int>
    {
        public ProductCategoryDto ProductCategoryDto { get; set; }
    }
}

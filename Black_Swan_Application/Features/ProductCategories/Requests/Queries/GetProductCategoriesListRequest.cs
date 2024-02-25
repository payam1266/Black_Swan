using Black_Swan_Application.DTOs.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.ProductCategories.Requests.Queries
{
    public class GetProductCategoriesListRequest : IRequest<List<ProductCategoryDto>>
    {
    }
}

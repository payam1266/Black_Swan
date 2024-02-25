using Black_Swan_Application.DTOs.Brand;
using MediatR;
using System.Collections.Generic;

namespace Black_Swan_Application.Features.Brands.Requests.Queries
{
    public class GetBrandListRequest:IRequest<List<BrandDto>>
    {
    }
}

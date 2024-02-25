using Black_Swan_Application.DTOs.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Brands.Requests.Queries
{
    public class GetBrandRequest:IRequest<BrandDto>
    {
        public int id { get; set; }
    }
}

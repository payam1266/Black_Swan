using Black_Swan_Application.DTOs.Brand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Brands.Requests.Commands
{
    public class UpdateBrandCommand:IRequest<Unit>
    {
        public BrandDto BrandDto { get; set; }
    }
}

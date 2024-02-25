using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Brands.Requests.Commands
{
    public class CreateBrandCommand:IRequest<BaseCommandResponse>
    {
        public CreateBrandDto  BrandDto{ get; set; }
    }
}

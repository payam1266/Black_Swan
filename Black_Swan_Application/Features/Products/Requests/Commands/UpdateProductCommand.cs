using Black_Swan_Application.DTOs.Product;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand:IRequest<BaseCommandResponse>
    {
        public UpdateProductDto ProductDto { get; set; }
    }
}

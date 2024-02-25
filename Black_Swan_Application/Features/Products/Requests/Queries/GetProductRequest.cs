using Black_Swan_Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Products.Requests.Queries
{
    public class GetProductRequest:IRequest<ProductDto>
    {
        public int id { get; set; }
    }
}

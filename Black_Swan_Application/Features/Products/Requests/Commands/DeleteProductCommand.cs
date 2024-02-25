using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Products.Requests.Commands
{
    public class DeleteProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

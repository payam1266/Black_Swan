using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Brands.Requests.Commands
{
    public class DeleteBrandCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

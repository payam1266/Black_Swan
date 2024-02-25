using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Orders.Requests.Commands
{
    public class DeleteOrderCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

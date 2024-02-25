using Black_Swan_Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Orders.Requests.Commands
{
    public class UpdateOrderCommand:IRequest<Unit>
    {
        public OrderDto OrderDto { get; set; }
    }
}

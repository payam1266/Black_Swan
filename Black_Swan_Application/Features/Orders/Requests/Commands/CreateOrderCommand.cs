using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Orders.Requests.Commands
{
    public class CreateOrderCommand:IRequest<BaseCommandResponse>
    {
        public OrderDto OrderDto { get; set; }
    }
}

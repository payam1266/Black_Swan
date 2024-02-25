using Black_Swan_Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.Orders.Requests.Queries
{
    public class GetOrderRequest:IRequest<OrderDto>
    {
        public int id { get; set; }
    }
}

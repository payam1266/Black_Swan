using Black_Swan_Application.DTOs.OrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.OrderDetail.Requests.Queries
{
    public class GetOrderDetailsRequest:IRequest<OrderDetailsDto>
    {
        public int id { get; set; }
    }
}

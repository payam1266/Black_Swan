using Black_Swan_Application.DTOs.OrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.OrderDetail.Requests.Commands
{
    public class UpdateOrderDetailsCommand:IRequest<Unit>
    {
        public OrderDetailsDto OrderDetailsDto { get; set; }
    }
}

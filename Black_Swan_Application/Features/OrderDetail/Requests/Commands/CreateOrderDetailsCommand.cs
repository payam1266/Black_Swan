using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.OrderDetail.Requests.Commands
{
    public class CreateOrderDetailsCommand:IRequest<BaseCommandResponse>
    {
        public OrderDetailsDto OrderDetailsDto{ get; set; }
    }
}

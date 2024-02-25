using Black_Swan_Application.DTOs.OrderDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.OrderDetail.Requests.Queries
{
    public class GetListOrderDetailsRequest:IRequest<List<OrderDetailsDto>>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.OrderDetail.Requests.Commands
{
    public class DeleteOrderDetailsCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

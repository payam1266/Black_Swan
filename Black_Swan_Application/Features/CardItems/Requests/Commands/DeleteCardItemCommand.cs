using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.CardItems.Requests.Commands
{
    public class DeleteCardItemCommand:IRequest<Unit>
    {
        public int id { get; set; }
    }
}

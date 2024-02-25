using Black_Swan_Application.DTOs.CardItem;
using Black_Swan_Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.CardItems.Requests.Commands
{
    public class CreateCartItemCommand:IRequest<BaseCommandResponse>
    {
        public CardItemDto CardItemDto { get; set; }
        
    }
}

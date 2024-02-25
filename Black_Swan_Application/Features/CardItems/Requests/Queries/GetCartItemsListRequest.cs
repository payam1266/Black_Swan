using Black_Swan_Application.DTOs.CardItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Swan_Application.Features.CardItems.Requests.Queries
{
    public class GetCartItemsListRequest:IRequest<List<CardItemDto>>
    {
    }
}

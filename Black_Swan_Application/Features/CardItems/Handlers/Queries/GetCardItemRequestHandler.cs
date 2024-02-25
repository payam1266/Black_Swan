using AutoMapper;
using Black_Swan_Application.DTOs.CardItem;
using Black_Swan_Application.Features.CardItems.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.CardItems.Handlers.Queries
{
    public class GetCardItemRequestHandler : IRequestHandler<GetCardItemRequest, CardItemDto>
    {
        private readonly ICardItemRepository _cardItemRepository;
        private readonly IMapper _mapper;

        public GetCardItemRequestHandler(ICardItemRepository cardItemRepository,IMapper mapper)
        {
            _cardItemRepository = cardItemRepository;
            _mapper = mapper;
        }
        public async Task<CardItemDto> Handle(GetCardItemRequest request, CancellationToken cancellationToken)
        {
            var cartItem = await _cardItemRepository.GetCardItem(request.id);
            return _mapper.Map<CardItemDto>(cartItem);
            
        }
    }
}

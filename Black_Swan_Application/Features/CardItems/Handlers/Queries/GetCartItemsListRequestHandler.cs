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
    public class GetCartItemsListRequestHandler : IRequestHandler<GetCartItemsListRequest, List<CardItemDto>>
    {
        private readonly ICardItemRepository _cardItemRepository;
        private readonly IMapper _mapper;

        public GetCartItemsListRequestHandler(ICardItemRepository cardItemRepository,IMapper mapper)
        {
            _cardItemRepository = cardItemRepository;
            _mapper = mapper;
        }
        public async Task<List<CardItemDto>> Handle(GetCartItemsListRequest request, CancellationToken cancellationToken)
        {
            var cardItem = await _cardItemRepository.GetListCardItems();
            return _mapper.Map<List<CardItemDto>>(cardItem);
        }
    }
}

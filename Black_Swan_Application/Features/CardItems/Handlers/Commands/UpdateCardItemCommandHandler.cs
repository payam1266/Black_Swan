using AutoMapper;
using Black_Swan_Application.Features.CardItems.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.CardItems.Handlers.Commands
{
    public class UpdateCardItemCommandHandler : IRequestHandler<UpdateCardItemCommand, Unit>
    {
        private readonly ICardItemRepository _cardItemRepository;
        private readonly IMapper _mapper;

        public UpdateCardItemCommandHandler(ICardItemRepository cardItemRepository,IMapper mapper)
        {
           _cardItemRepository = cardItemRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCardItemCommand request, CancellationToken cancellationToken)
        {
            var cardItem = await _cardItemRepository.Get(request.CardItemDto.id);
           _mapper.Map(request.CardItemDto, cardItem);
            await _cardItemRepository.Update(cardItem);
            return Unit.Value;
        }
    }
}

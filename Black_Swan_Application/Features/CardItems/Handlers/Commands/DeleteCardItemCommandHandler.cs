using AutoMapper;
using Black_Swan_Application.Exceptions;
using Black_Swan_Application.Features.CardItems.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.CardItems.Handlers.Commands
{
    public class DeleteCardItemCommandHandler : IRequestHandler<DeleteCardItemCommand, Unit>
    {
        private readonly ICardItemRepository _cardItemRepository;
        private readonly IMapper _mapper;

        public DeleteCardItemCommandHandler(ICardItemRepository cardItemRepository,IMapper mapper)
        {
            _cardItemRepository = cardItemRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteCardItemCommand request, CancellationToken cancellationToken)
        {
            var cardItem = await _cardItemRepository.Get(request.id);
            if (cardItem == null)
            {
                throw new NotFoundException(nameof(CardItem), request.id);
            }
            await _cardItemRepository.Delete(cardItem);
            return Unit.Value;
            
        }
    }
}

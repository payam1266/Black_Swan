using AutoMapper;
using Black_Swan_Application.Exceptions;
using Black_Swan_Application.Features.OrderDetail.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.OrderDetail.Handlers.Commands
{
    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand, Unit>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public DeleteOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository,IMapper mapper)
        {
            _orderDetailsRepository = orderDetailsRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailsRepository.Get(request.id);
            if (orderDetail == null)
            {
                throw new NotFoundException(nameof(OrderDetails), request.id);
            }
            await _orderDetailsRepository.Delete(orderDetail);
            return Unit.Value;
        }
    }
}

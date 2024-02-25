using AutoMapper;
using Black_Swan_Application.Features.Orders.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Orders.Handlers.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper)
        {
           _orderRepository = orderRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.Get(request.OrderDto.id);
            _mapper.Map(request.OrderDto, order);
            await _orderRepository.Update(order);
            return Unit.Value;

        }
    }
}

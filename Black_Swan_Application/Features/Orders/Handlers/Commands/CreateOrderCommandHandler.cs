using AutoMapper;
using Black_Swan_Application.Features.Orders.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Orders.Handlers.Commands
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand, BaseCommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly ICardItemRepository _cardItemRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper,IOrderDetailsRepository orderDetailsRepository,ICardItemRepository cardItemRepository)
        {
           _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
           _cardItemRepository = cardItemRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
         



            var order = _mapper.Map<Order>(request.OrderDto);
            order = await _orderRepository.Add(order);
            response.success = true;
            response.message = "Creation Successful.";
            response.id = order.id;
            return response;
        }

        
    }
}

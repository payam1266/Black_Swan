using AutoMapper;
using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.Features.Orders.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Orders.Handlers.Queries
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
           _mapper = mapper;
        }
        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrder(request.id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}

using AutoMapper;
using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.Features.Orders.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Orders.Handlers.Queries
{
    public class GetOrderListRequestHandler : IRequestHandler<GetOrderListRequest, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListRequestHandler(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<OrderDto>> Handle(GetOrderListRequest request, CancellationToken cancellationToken)
        {
            var orderList = await _orderRepository.GetListOrders();
            return _mapper.Map<List<OrderDto>>(orderList);

        }
    }
}

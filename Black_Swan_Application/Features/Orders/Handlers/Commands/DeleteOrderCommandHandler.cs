using AutoMapper;
using Black_Swan_Application.Exceptions;
using Black_Swan_Application.Features.Orders.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Orders.Handlers.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository,IMapper mapper,IOrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
           
           
           var OrderDetail= await _orderDetailsRepository.GetAll();
            if (OrderDetail == null)
            {
                throw new NotFoundException(nameof(OrderDetail),request.id );
            }
            foreach (var item in OrderDetail)
            {
                if (item.orderId == request.id)
                   await _orderDetailsRepository.Delete(item);
            }
            var order = await _orderRepository.Get(request.id);
            if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.id);
            }
            await _orderRepository.Delete(order);
            return Unit.Value;
        }
    }
}

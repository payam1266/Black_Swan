using AutoMapper;
using Black_Swan_Application.Features.OrderDetail.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.OrderDetail.Handlers.Commands
{
    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, Unit>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository,IMapper mapper)
        {
            _orderDetailsRepository = orderDetailsRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailsRepository.Get(request.OrderDetailsDto.id);
            _mapper.Map(request.OrderDetailsDto, orderDetail);
            return Unit.Value;
        }
    }
}
